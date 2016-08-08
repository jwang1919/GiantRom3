using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;

public class QTETrigger : MonoBehaviour {
  public enum QTEState { Ready, Ongoing, Done };
  public QTEState state = QTEState.Ready;
  public enum QTEResponse { Null, Success, Fail };
  public QTEResponse response = QTEResponse.Null;

  public List<string> Buttons = new List<string>();
  public List<string> CopyButtons;
  public Image buttonDisplay;


  private int randomNumber = 0;


  void Awake() {
    CopyButtons = new List<string>(Buttons);
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
          state = QTEState.Done;
          buttonDisplay.enabled = false;
          FirstPersonController.unpause();
          Destroy(gameObject);
        } else {
          PickRandomButton();
        }
      } else {
        state = QTEState.Ready;
        response = QTEResponse.Null;
        FirstPersonController.unpause();
        buttonDisplay.enabled = false;
        Buttons.Clear();
        Buttons = new List<string>(CopyButtons);
      }
    }

  }

  private void PickRandomButton() {
    int count = Buttons.Count;
    buttonDisplay.enabled = true;
    if (count > 0) {
      state = QTEState.Ongoing;
      randomNumber = Random.Range(0, Buttons.Count);

      // dynamically load button sprite by name, idea is to avoid hard coding as much as possible
      buttonDisplay.sprite = Resources.Load("keys/" + Buttons[randomNumber], typeof(Sprite)) as Sprite;
    }

  }

}