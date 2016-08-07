using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class QTETrigger : MonoBehaviour {
  public enum QTEState { Ready, Delay, Ongoing, Done };
  public QTEState state = QTEState.Ready;
  public enum QTEResponse { Null, Success, Fail };
  public QTEResponse response = QTEResponse.Null;

  public bool randomPrompts = true;

  public List<string> Buttons = new List<string>();

  public float eventTimer = 2f;
  public float delay = 0f;
  private int randomNumber = 0;
  private int counter = 0;

  public Text buttonDisplay;
  void OnTriggerEnter(Collider c) {
    if (state == QTEState.Ready && c.tag == "Player")
      StartCoroutine(StateChange());
  }

  // Update is called once per frame
  void Update() {
    if (state == QTEState.Ongoing) {
      if (randomPrompts == true) {
        if (Input.anyKeyDown) {
          if (Buttons[randomNumber] == Input.inputString) {
            state = QTEState.Done;
            response = QTEResponse.Success;
            buttonDisplay.text = "";
            StopCoroutine(StateChange());
          }
        }
      } else {
        if (Input.anyKeyDown) {
          if (Buttons[randomNumber] == Input.inputString) {
            state = QTEState.Done;
            response = QTEResponse.Success;
            buttonDisplay.text = "";
            StopCoroutine(StateChange());
          }
        }
      }
    }
  }

  private IEnumerator StateChange() {
    state = QTEState.Delay;
    counter = 0;
    //yield return new WaitForSeconds(delay);
    while (counter < Buttons.Count) {
      if (randomPrompts == true)
        randomNumber = Random.Range(0, Buttons.Count);
      else
        randomNumber = 0;

      buttonDisplay.text = Buttons[randomNumber];
      state = QTEState.Ongoing;
      counter++;
      yield return new WaitForSeconds(delay);
    }
    yield return new WaitForSeconds(eventTimer);

    if (state == QTEState.Ongoing) {

      response = QTEResponse.Fail;
      state = QTEState.Done;
      buttonDisplay.text = "";
    }
  }


}