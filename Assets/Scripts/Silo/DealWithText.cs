using UnityEngine;
public class DealWithText : MonoBehaviour
{

    private GameObject flav;
    bool flavIsOn;
    // Use this for initialization
    void Start()
    {
        flav = GameObject.Find("FlavorText");
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
        if (Input.anyKey)
        {
            flav.SetActive(false);
            flavIsOn = !flavIsOn;
        }
    }
}