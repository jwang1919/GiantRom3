using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class LadderBehaviour: MonoBehaviour {

  public GameObject player;
  public string keyToPress;
  public Text buttonPressInteract;
  public Image buttonToPress;

  void Awake() {
    buttonToPress.sprite = Resources.Load("keys/" + keyToPress, typeof(Sprite)) as Sprite;
  }
  void OnTriggerEnter(Collider c){
    if (c.tag == "Player") {
      buttonPressInteract.text = "Hold to Climb";
      buttonToPress.enabled = true;
      player.GetComponent<FirstPersonController>().m_GravityMultiplier = 0f;
    }
  }

  void OnTriggerExit(Collider c) {
    if (c.tag == "Player") {
      buttonPressInteract.text = "";
      buttonToPress.enabled = false;
      player.GetComponent<FirstPersonController>().m_GravityMultiplier = 2f;
    }
  }

    void OnTriggerStay(Collider c)
    {
        if (c.tag == "Player" && Input.GetKey(keyToPress))
        {
            player.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * 6f);
        }
    }
    
}
