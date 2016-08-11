using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;

[RequireComponent (typeof (AudioSource))]
public class QTETrigger : MonoBehaviour {
  public enum QTEState { Ready, Ongoing, Done };
  public QTEState state = QTEState.Ready;
  public enum QTEResponse { Null, Success, Fail };
  public QTEResponse response = QTEResponse.Null;

    
  public List<AudioClip> successSounds = new List<AudioClip>();
  public List<AudioClip> failSounds = new List<AudioClip>();


  public bool shouldObjectBeDestroyed = false;

  public List<string> Buttons = new List<string>();
  
  public Image buttonDisplay;
  public bool randomize;
  public GameObject nextObjectToActivate;

  private List<string> CopyButtons;
  private int randomNumber = 0;
  private AudioSource audioSource;

  void Awake() {
    CopyButtons = new List<string>(Buttons);
    audioSource = GetComponent<AudioSource>();
  }

  void OnTriggerEnter(Collider c) {
    if (state == QTEState.Ready && c.tag == "Player") {
      // Modded FirstPersonController to have a static variable to freeze the script
      FirstPersonController.pause();
      PickRandomButton();
    }
  }

  void Update() {
    if (state == QTEState.Ongoing && Input.anyKeyDown) {
      if (Input.GetKeyDown(Buttons[randomNumber])) {
        state = QTEState.Done;
        response = QTEResponse.Success;
        Buttons.RemoveAt(randomNumber);
        if (Buttons.Count == 0) {
          PlayRandomSuccessSound();
          buttonDisplay.enabled = false;                    
          state = QTEState.Done;
        } else {
          PickRandomButton();
        }
      } else {
        PlayRandomFailSound();
        state = QTEState.Ready;
        response = QTEResponse.Null;
        FirstPersonController.unpause();
        buttonDisplay.enabled = false;
        Buttons.Clear();
        Buttons.AddRange(CopyButtons);
      }
    }

    if (state == QTEState.Done && !audioSource.isPlaying) {
      FirstPersonController.unpause();
      if (nextObjectToActivate != null) {
        nextObjectToActivate.SetActive(true);
      }
      if (shouldObjectBeDestroyed)
        Destroy(gameObject);
      else {
        gameObject.SetActive(false);
      }
    }
  }

  private void PickRandomButton() {
    int count = Buttons.Count;
    buttonDisplay.enabled = true;
    if (count > 0) {
      state = QTEState.Ongoing;
      if (randomize) {
        randomNumber = Random.Range(0, Buttons.Count);
      }

      // dynamically load button sprite by name, idea is to avoid hard coding as much as possible
      buttonDisplay.sprite = Resources.Load("keys/" + Buttons[randomNumber], typeof(Sprite)) as Sprite;
    }

  }

  private void PlayRandomSuccessSound() {
    int count = successSounds.Count;

    if (count > 0 && audioSource != null){
      audioSource.Stop();
      audioSource.clip = successSounds[Random.Range(0, count)];
      audioSource.Play();
    }
  }

   private void PlayRandomFailSound() {
     int count = failSounds.Count;

     if (count > 0 && audioSource != null) {
       audioSource.Stop();
       audioSource.clip = failSounds[Random.Range(0, count)];
       audioSource.Play();
     }
   }

}