using UnityEngine;
using System.Collections;

public class CloseExplosionsState : MonoBehaviour {

    public AudioClip clip;
    public int startTime = 0;

    private ScreenShake screenShake;

    void Start()
    {
        screenShake = GameObject.FindGameObjectWithTag("Player").GetComponent<ScreenShake>();
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
            screenShake.Shake();
            audioSource.Play();
            timeline.AddOrder();
        }
    }
}
