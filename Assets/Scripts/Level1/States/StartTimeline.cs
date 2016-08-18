using UnityEngine;
using UnityEngine.UI;

public class StartTimeline : MonoBehaviour {
    
    private GameObject welcomeText;

	// Use this for initialization
	void Start () {
	    welcomeText = GameObject.FindGameObjectWithTag("Welcome");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
        {
            welcomeText.SetActive(false);
            GetComponent<Timeline>().enabled = true;
            this.enabled = false;
        }
    }
}
