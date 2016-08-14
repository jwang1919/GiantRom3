using UnityEngine;
using System.Collections;

public class AirRaidState : MonoBehaviour {

    public AudioClip clip;
    public int startTime = 0;

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
            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
            timeline.AddOrder();
        }
    }
}
