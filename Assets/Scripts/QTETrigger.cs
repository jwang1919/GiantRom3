using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;

public class QTETrigger : MonoBehaviour
{
    public enum QTEState { Ready, Ongoing, Done };
    public QTEState state = QTEState.Ready;
    public enum QTEResponse { Null, Success, Fail };
    public QTEResponse response = QTEResponse.Null;

    public List<string> Buttons = new List<string>();
    
    public Image buttonDisplay;
    private int randomNumber = 0;

    void OnTriggerEnter(Collider c)
    {
        if (state == QTEState.Ready && c.tag == "Player")
        {
            // Modded FirstPersonController to have a static variable to freeze the script
            FirstPersonController.pause();
            PickRandomButton();
            buttonDisplay.enabled = true;
        }
    }
    
    void Awake()
    {
        Buttons.Add("b");
        Buttons.Add("g");
        Buttons.Add("i");
        Buttons.Add("m");
        Buttons.Add("n");
        Buttons.Add("o");
        Buttons.Add("t");
    }
    
    void Update()
    {
        if (state == QTEState.Ongoing && Input.anyKeyDown)
        {
            if (Input.GetKeyDown(Buttons[randomNumber]))
            {
                state = QTEState.Done;
                response = QTEResponse.Success;
                print("correct!");
                Buttons.RemoveAt(randomNumber);
                if (Buttons.Count == 0)
                {
                    state = QTEState.Done;
                    print("woohoo your done!");
                    buttonDisplay.enabled = false;
                    FirstPersonController.unpause();
                }
                else
                {
                    PickRandomButton();
                }
            }
            else
            {
                print("wrong!");
            }
        }
    }

    private void PickRandomButton()
    {
        int count = Buttons.Count;
        if (count > 0)
        {
            state = QTEState.Ongoing;
            randomNumber = Random.Range(0, Buttons.Count);

            // dynamically load button sprite by name, idea is to avoid hard coding as much as possible
            buttonDisplay.sprite = Resources.Load("keys/" + Buttons[randomNumber], typeof(Sprite)) as Sprite;
        }
    }
    
}