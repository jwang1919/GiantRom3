using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CheckVideo : MonoBehaviour {

  StartProjector movie;
  Image load;
	// Use this for initialization
	void Start () {
    movie = gameObject.GetComponentInChildren<StartProjector>();
    load = GameObject.Find("Load").GetComponent<Image>();
    load.CrossFadeAlpha(0f, 0f, true);
	}
	
	// Update is called once per frame
	void Update () {
    if (movie.playing) {
      StartCoroutine(WaitingForMovie(movie.movie.duration, OnWaitFinish));
    }
	}
  void OnWaitFinish() {
    load.CrossFadeAlpha(1f, 3f, true);
  }

  IEnumerator WaitingForMovie(float duration, System.Action callback){
    while (movie.movie.isPlaying) {
      yield return 0;
    }
    if (callback != null) callback();
    yield break;
  }
}
