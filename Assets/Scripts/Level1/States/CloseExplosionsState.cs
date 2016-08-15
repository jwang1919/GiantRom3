using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CloseExplosionsState : MonoBehaviour {

    public AudioClip clip;
    public int startTime = 0;

    public Image camEffect;
    private ScreenShake screenShake;

    void Start()
    {
        if (camEffect == null)
        {
            throw new System.Exception("Cam Effect should be defined!");
        }

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

            camEffect.CrossFadeAlpha(0.5f, 5f, true);
            timeline.AddOrder();
        }
    }
}
