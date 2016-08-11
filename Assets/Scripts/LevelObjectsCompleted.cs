using UnityEngine;
using System.Collections;

public class LevelObjectsCompleted : MonoBehaviour {

  public GameObject[] collectibles;
  public GameObject loader;
  bool levelCompleted;
	// Use this for initialization
	void Awake () {
      loader.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
    CheckIfLevelObjectsCollected();
	}

  void CheckIfLevelObjectsCollected() {
    for (int i = 0; i < collectibles.Length; i++) {
      if (collectibles[i].activeSelf == false) {
        levelCompleted = true;
      } else {
        levelCompleted = false;
      }

    }

    if (levelCompleted == true)
      loader.SetActive(true);
  }
}
