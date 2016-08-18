using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
public class DealWithText : MonoBehaviour
{

    Image flav;
    Text flavT;
    bool flavIsOn;

    public KeyCode keyToStart = KeyCode.Space;
    // Use this for initialization
    void Start()
    {
        FirstPersonController.pause();
        flav = GameObject.Find("FlavorText").GetComponent<Image>();
        flavT = flav.GetComponentInChildren<Text>();
        flavT.text = "Press " + keyToStart.ToString().ToUpper() + " to start";
        flavIsOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (flavIsOn)
        {

            RidText();
        }
    }

    void RidText()
    {
        if (Input.GetKeyDown(keyToStart))
        {
            flav.enabled = false;
            flavT.enabled = false;
            flavIsOn = !flavIsOn;
            FirstPersonController.unpause();
        }
    }
}