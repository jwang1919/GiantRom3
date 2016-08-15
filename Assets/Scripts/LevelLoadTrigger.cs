using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
public class LevelLoadTrigger : MonoBehaviour {
  public GameObject cam;
  public float smooth = 1f;
  public string keyToPress;
  public string levelToLoad;
  public Text buttonPressInteract;
  public Image buttonToPress;
  bool toggle;
  public Image camEffect;
  // Use this for initialization
  void Awake() {
    camEffect.CrossFadeAlpha(0f, 5f, true);
    buttonToPress.sprite = Resources.Load("keys/" + keyToPress, typeof(Sprite)) as Sprite;
  }

  // Update is called once per frame
  void Update() {
    //StartCoroutine(CameraEffects());
  }

  void OnTriggerEnter(Collider c) {
    if (c.tag == "Player") {
      buttonPressInteract.text = "Press";
      buttonToPress.enabled = true;
    }
  }
  void OnTriggerStay(Collider c) {
    if (c.tag == "Player" && Input.GetKeyDown(keyToPress)) {
      StartCoroutine(CameraEffects(levelToLoad));
    }
  }
  void OnTriggerExit(Collider c) {
    if (c.tag == "Player") {
      buttonPressInteract.text = "";
      buttonToPress.enabled = false;
    }
  }

  IEnumerator CameraEffects(string level) {
    //camEffect.CrossFadeAlpha(1f, 5f, true);
    //camEffect.enabled = true;
    AsyncOperation async = SceneManager.LoadSceneAsync(level);
    while (!async.isDone) {
      camEffect.CrossFadeAlpha(1f, async.progress / 50, false);
      yield return null;
    }
  }


}
