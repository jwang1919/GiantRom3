using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
public class DealWithText : MonoBehaviour {

  Text flav;
  bool flavIsOn;
	// Use this for initialization
	void Start () {
    FirstPersonController.pause();
    flav = GameObject.Find("FlavorText").GetComponent<Text>();
    flavIsOn = true;
	}
	
	// Update is called once per frame
	void Update () {
	  if(flavIsOn){
      
      RidText();
    }
	}

  void RidText() {
    if (Input.GetKeyDown(KeyCode.Space)) {
      flav.enabled = false;
      flavIsOn = !flavIsOn;
      FirstPersonController.unpause();
    }
  }
}
