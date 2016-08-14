using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class LadderBehaviour: MonoBehaviour {

  public GameObject player;
  public string keyToPress;
  public Text buttonPressInteract;
  public Image buttonToPress;
  public bool climb;

  void Awake() {
    buttonToPress.sprite = Resources.Load("keys/" + keyToPress, typeof(Sprite)) as Sprite;
  }
  void OnTriggerEnter(Collider c){
    if (c.tag == "Player") {
      buttonPressInteract.text = "Hold to Climb";
      buttonToPress.enabled = true;
      climb = true;
      player.GetComponent<FirstPersonController>().m_GravityMultiplier = 0f;
    }
    
  }
  void OnTriggerExit(Collider c) {
    if (c.tag == "Player") {
      buttonPressInteract.text = "";
      buttonToPress.enabled = false;
      climb = false;
      player.GetComponent<FirstPersonController>().m_GravityMultiplier = 2f;
    }
  }

  void Update() {
    if (climb == true && Input.GetKey(KeyCode.F)) {
      player.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * 5f);
    }
  }
}
