using UnityEngine;
using System.Collections;

public class DisableOnStart : MonoBehaviour {

    public bool disableOnStart = true;

	void Start () {
        gameObject.SetActive(!disableOnStart);
	}
	
}
