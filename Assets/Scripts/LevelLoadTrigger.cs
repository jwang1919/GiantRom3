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
  public Light camEffect;
  // Use this for initialization
  void Awake() {
    
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
    for (int i = 0; i < 20; i++) {
      camEffect.intensity = i;
    }
    AsyncOperation async = SceneManager.LoadSceneAsync(level);
    while (!async.isDone) {
      
      //if(camEffect.bloomIntensity <=4 && camEffect.bloomIntensity >=-4)
      camEffect.intensity -= async.progress * 100;
      yield return null;
    }
  }


}
