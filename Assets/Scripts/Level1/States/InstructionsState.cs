using UnityEngine;
using System.Collections;

public class InstructionsState : MonoBehaviour {

    public AudioClip clip;
    public int startTime = 0;

    public GameObject[] instructions;

    void Start()
    {
        // not used
    }

    void Update()
    {
        // not used
    }

    public void Run(Timeline timeline, AudioSource audioSource)
    {
        if (timeline.GetCurrentTime() > startTime)
        {
            foreach (GameObject instruction in instructions)
            {
                instruction.SetActive(true);
            }

            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
            timeline.AddOrder();
        }
    }
}
