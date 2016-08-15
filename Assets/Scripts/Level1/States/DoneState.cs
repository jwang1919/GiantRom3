using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoneState : MonoBehaviour {
    
    public int startTime = 0;
    public string levelToLoad;
    public Image camEffect;
    
    void Start()
    {
        if (levelToLoad == null)
        {
            throw new System.Exception("Next level should be defined!");
        }
        
        if (camEffect == null)
        {
            throw new System.Exception("Cam Effect should be defined!");
        }
    }

    void Update()
    {
        // not used
    }

    public void Run(Timeline timeline)
    {
        if (timeline.GetCurrentTime() > startTime)
        {
            StartCoroutine(CameraEffects());
        }
    }
    
    private IEnumerator CameraEffects()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(levelToLoad);
        while (!async.isDone)
        {
            camEffect.CrossFadeAlpha(1f, async.progress / 50, false);
            yield return null;
        }
    }
}
