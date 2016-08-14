using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

    public int seconds = 0;
    private float timeSinceStarted;
    private BombsAboutToDrop script;
	// Use this for initialization
	void Start () {
    script = GameObject.Find("Level1GameManager").GetComponent<BombsAboutToDrop>();
	}
	
	// Update is called once per frame
	void Update () {
    if (Input.GetKeyDown(KeyCode.Space)) {
      timeSinceStarted = Time.time;
    }
    if (seconds+timeSinceStarted < Time.time && script.welcome.enabled == false) {
            Destroy(gameObject);
        }
	}
}
