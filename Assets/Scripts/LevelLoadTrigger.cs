using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityStandardAssets.ImageEffects;
public class LevelLoadTrigger : MonoBehaviour {
  public GameObject cam;
  public string keyToPress;
  public string levelToLoad;
  public Text buttonPressInteract;
  public Image buttonToPress;
  Bloom camEffect;
  bool toggle;
  // Use this for initialization
  void Awake() {
    camEffect = cam.GetComponent<Bloom>();
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
    if (c.tag == "Player" && Input.GetKeyDown(keyToPress))
      StartCoroutine(CameraEffects(levelToLoad));
  }
  void OnTriggerExit(Collider c) {
    if (c.tag == "Player") {
      buttonPressInteract.text = "";
      buttonToPress.enabled = false;
    }
  }

  IEnumerator CameraEffects(string level) {
    camEffect.bloomIntensity = -4f;
    AsyncOperation async = SceneManager.LoadSceneAsync(level);
    while (!async.isDone) {
      
      if(camEffect.bloomIntensity <=4 && camEffect.bloomIntensity >=-4)
      camEffect.bloomIntensity = async.progress * 100/90;
      yield return null;
    }
  }


}
