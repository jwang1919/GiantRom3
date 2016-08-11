using UnityEngine;
using System.Collections;

public class DisableOnStart : MonoBehaviour {

    public bool disableOnStart = false;

	void Start () {
        gameObject.SetActive(!disableOnStart);
	}
	
	void Update () {
	 // do nothing
	}
}
