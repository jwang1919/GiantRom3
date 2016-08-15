using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class PromptAndPlaySound : MonoBehaviour {

    public enum DisplayState {Ready, Active, Playing};
    public DisplayState state;
    public Image buttonDisplay;
    public AudioClip[] sounds;

    private int soundCount = 0;
    private AudioSource audioSource;

    void Start () {
        audioSource = GetComponent<AudioSource>();
        if (sounds != null) {
            soundCount = sounds.Length;
        }
        state = DisplayState.Ready;
    }

    void OnTriggerEnter(Collider c) {
        if (state == DisplayState.Ready && c.tag == "Player") {
            state = DisplayState.Active;
            buttonDisplay.enabled = true;
        }
    }

    void OnTriggerStay(Collider c) {
        if (c.tag != "Player" && soundCount > 0) {
            return;
        }

        if (state == DisplayState.Ready) {
            state = DisplayState.Active;
            buttonDisplay.enabled = true;
        } else if (state == DisplayState.Active && Input.GetKeyDown(KeyCode.E)) {
            int index = 0;
            if (soundCount > 1) {
                index = Random.Range(0, sounds.Length);
            }
            audioSource.Stop();
            audioSource.clip = sounds[index];
            audioSource.Play();
            state = DisplayState.Playing;
            buttonDisplay.enabled = false;
        }
    }

    void OnTriggerExit(Collider c) {
        if (c.tag == "Player") {
            state = DisplayState.Ready;
            buttonDisplay.enabled = false;
        }
    }

    void Update() {
        if (state == DisplayState.Playing && !audioSource.isPlaying) {
            state = DisplayState.Ready;
        }
    }
    
}
