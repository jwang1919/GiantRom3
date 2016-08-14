using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BombsAboutToDrop : MonoBehaviour {

    public enum AudioState {Memorize, Ready, PlaySiren, PlayEncouragment, PlayFarExplosion, PlayCloseExplosion, Done}

    public int seconds = 0;
    public AudioClip memorize;
    public AudioClip siren;
    public AudioClip encouragement;
    public AudioClip farExplosion;
    public AudioClip closeExplosion;
    public AudioState state;

    private AudioSource audioSource;
    private float timeSinceStarted;
    public Text welcome;

    // Use this for initialization
    void Start () {
        state = AudioState.Ready;
        audioSource = GetComponent<AudioSource>();
        welcome = GameObject.FindGameObjectWithTag("Welcome").GetComponent<Text>();
        welcome.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
    if (Input.GetKeyDown(KeyCode.Space)) {
      welcome.enabled = false;
      timeSinceStarted = Time.time;
      Debug.Log(timeSinceStarted);
    }
    if (welcome.enabled == false && seconds + timeSinceStarted < Time.time && state == AudioState.Ready) {
            state = AudioState.Memorize;
        }
        
        switch (state) {
          case AudioState.Memorize:
            if (!audioSource.isPlaying) {
              playSound(memorize);
              state = AudioState.PlayFarExplosion;
            }
              break;
            case AudioState.PlayFarExplosion:
              if (!audioSource.isPlaying) {
                playSound(farExplosion);
                state = AudioState.PlaySiren;
              }
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
