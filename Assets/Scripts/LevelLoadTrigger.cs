using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityStandardAssets.ImageEffects;
public class LevelLoadTrigger : MonoBehaviour {
  public GameObject cam;
  public string levelToLoad;
  Bloom camEffect;
  bool toggle;
  // Use this for initialization
  void Awake() {
    camEffect = cam.GetComponent<Bloom>();
  }

  // Update is called once per frame
  void Update() {
    //StartCoroutine(CameraEffects());
  }

  void OnTriggerEnter(Collider c) {
    if(c.tag == "Player")
    StartCoroutine(CameraEffects(levelToLoad));
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
