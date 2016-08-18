using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartTimeline : MonoBehaviour {

    public KeyCode keyToStartTimeline = KeyCode.Space;

    private Image welcomeImage;
    private Text welcomeImageText;
	// Use this for initialization
	void Start () {
	    welcomeImage = GameObject.FindGameObjectWithTag("Welcome").GetComponent<Image>();
      welcomeImageText = welcomeImage.GetComponentInChildren<Text>();
      welcomeImageText.text = "Press " + keyToStartTimeline.ToString().ToUpper() +" to start";
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(keyToStartTimeline))
        {
            welcomeImage.enabled = false;
            welcomeImageText.enabled = false;
            GetComponent<Timeline>().enabled = true;
            this.enabled = false;
        }
    }
}
