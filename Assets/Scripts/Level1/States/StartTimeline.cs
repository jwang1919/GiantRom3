using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartTimeline : MonoBehaviour {

    public KeyCode keyToStartTimeline = KeyCode.Space;

    private Text welcomeText;

	// Use this for initialization
	void Start () {
	    welcomeText = GameObject.FindGameObjectWithTag("Welcome").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(keyToStartTimeline))
        {
            welcomeText.enabled = false;
            GetComponent<Timeline>().enabled = true;
            this.enabled = false;
        }
    }
}
