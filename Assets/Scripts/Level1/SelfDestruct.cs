using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

    public int seconds = 0;

    private float currentTime = 0;
    
	// Update is called once per frame
	void Update () {
        if (currentTime > seconds)
        {
            Destroy(gameObject);
        }

        currentTime += Time.deltaTime;
	}
}
