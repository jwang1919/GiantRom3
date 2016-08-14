using UnityEngine;
using System.Collections;

public class StartTimeline : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T))
        {
            GetComponent<Timeline>().enabled = true;
        }
    }
}
