using UnityEngine;
using System.Collections;
using System;

public class StartProjector : MonoBehaviour {

    public MovieTexture movie;

    private GameObject screen;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        screen = GameObject.FindGameObjectWithTag("Screen");
        if (screen == null)
        {
            throw new SystemException("Screen not found");
        }

        screen.GetComponent<Renderer>().material.mainTexture = movie;
        audioSource = screen.GetComponent<AudioSource>();
        audioSource.clip = movie.audioClip;
    }

    void OnTriggerStay(Collider c)
    {
        if (c.tag == "Player" && Input.GetKeyDown(KeyCode.E) && !movie.isPlaying)
        {
            Debug.Log("Playing videos");
            audioSource.Play();
            movie.Play();
        }
    }
}
