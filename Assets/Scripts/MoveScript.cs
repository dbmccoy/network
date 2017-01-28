﻿using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		float step = Time.deltaTime * 2;

		transform.Translate(new Vector3(x,0,z) * step);
	}
}
