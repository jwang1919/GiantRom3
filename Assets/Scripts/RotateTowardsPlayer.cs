﻿using UnityEngine;
using System.Collections;

public class RotateTowardsPlayer : MonoBehaviour {

  public Transform player;

	
	// Update is called once per frame
	void Update () {
    transform.LookAt(player);
    transform.eulerAngles = new Vector3(0,transform.eulerAngles.y,0);
	}
}
