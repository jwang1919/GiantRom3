using UnityEngine;
using System.Collections;

public class BombsAboutToDrop : MonoBehaviour {

    public enum AudioState {Ready, PlaySiren, PlayEncouragment, PlayFarExplosion, PlayCloseExplosion, Done}

    public int seconds = 0;
    public AudioClip siren;
    public AudioClip encouragement;
    public AudioClip farExplosion;
    public AudioClip closeExplosion;
    public AudioState state;

    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        state = AudioState.Ready;
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad > seconds && state == AudioState.Ready) {
            state = AudioState.PlayFarExplosion;
        }
        
        switch (state) {
            case AudioState.PlayFarExplosion:
                playSound(farExplosion);
                state = AudioState.PlaySiren;
                break;
            case AudioState.PlaySiren:
                if (!audioSource.isPlaying) {
                    playSound(siren);
                    state = AudioState.PlayEncouragment;
                }
                break;
            case AudioState.PlayEncouragment:
                if (!audioSource.isPlaying) {
                    playSound(encouragement);
                    state = AudioState.PlayCloseExplosion;
                }
                break;
            case AudioState.PlayCloseExplosion:
                if (!audioSource.isPlaying)
                {
                    playSound(closeExplosion);
                    state = AudioState.Done;
                }
                break;
        }

        if (state == AudioState.Done && !audioSource.isPlaying) {
            Destroy(gameObject);
        }
    }

    private void playSound(AudioClip clip) {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    } 
}
