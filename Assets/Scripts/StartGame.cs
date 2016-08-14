using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartGame : MonoBehaviour {

  public string level = "Level1";
  public Text pressToStart;
  Camera mainCamera;
  void Awake() {
    mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    StartCoroutine(Flash());
  }
	// Update is called once per frame
	void Update () {
    if (Input.GetKeyDown(KeyCode.Space)) {
      mainCamera.backgroundColor = Color.white;
      SceneManager.LoadScene(level);
    }
    if (Input.GetKeyDown(KeyCode.Escape)) {
      Application.Quit();
    }
	}

  IEnumerator Flash() {
    while (true) {
      yield return new WaitForSeconds(.5f);
      pressToStart.enabled = true;
      yield return new WaitForSeconds(.5f);
      pressToStart.enabled = false;
    }
  }
}
