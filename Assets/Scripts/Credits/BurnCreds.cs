using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BurnCreds : MonoBehaviour {
  [SerializeField]
  float waitTime = 1f;
  Text cred;
  Text mainTeam;
  Text art;
  Text program;
  Text other;
  Text thanks;
  Text seriously;
	// Use this for initialization
	void Start () {
    cred = GameObject.Find("Credits").GetComponent<Text>();
    mainTeam = GameObject.Find("Main").GetComponent<Text>();
    art = GameObject.Find("Art").GetComponent<Text>();
    program = GameObject.Find("Programming").GetComponent<Text>();
    thanks = GameObject.Find("ThankYou").GetComponent<Text>();
    seriously = GameObject.Find("Seriously").GetComponent<Text>();
    cred.enabled = false;
    mainTeam.enabled = false;
    art.enabled = false;
    program.enabled = false;
    thanks.enabled = false;
    seriously.enabled = false;
    StartCoroutine(RollCredits());
	}

  void Update() {
    if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
      Application.Quit();
  }
	
   IEnumerator RollCredits(){
    cred.enabled = true;
    cred.CrossFadeAlpha(0f, 0f, true);
    cred.CrossFadeAlpha(1f, .5f, true);
    yield return new WaitForSeconds(waitTime);
    cred.CrossFadeAlpha(0f, .5f, true);
    yield return new WaitForSeconds(waitTime);
    cred.enabled = false;

    mainTeam.enabled = true;
    mainTeam.CrossFadeAlpha(0f, 0f, true);
    mainTeam.CrossFadeAlpha(1f, .5f, true);
    yield return new WaitForSeconds(waitTime);
    mainTeam.CrossFadeAlpha(0f, 5f, true);
    yield return new WaitForSeconds(waitTime);
    mainTeam.enabled = false;

    art.enabled = true;
    art.CrossFadeAlpha(0f, 0f, true);
    art.CrossFadeAlpha(1f, .5f, true);
    yield return new WaitForSeconds(waitTime);
    art.CrossFadeAlpha(0f, .5f, true);
    yield return new WaitForSeconds(waitTime);
    art.enabled = false;

    program.enabled = true;
    program.CrossFadeAlpha(0f, 0f, true);
    program.CrossFadeAlpha(1f, .5f, true);
    yield return new WaitForSeconds(waitTime);
    program.CrossFadeAlpha(0f, .5f, true);
    yield return new WaitForSeconds(waitTime);
    program.enabled = false;
    thanks.enabled = true;
    yield return new WaitForSeconds(120f);
    thanks.enabled = false;
    seriously.enabled = true;
  }
}
