using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

    public int seconds = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Time.timeSinceLevelLoad > seconds) {
            Destroy(gameObject);
        }
	}
}
