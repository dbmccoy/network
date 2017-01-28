using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Obj : MonoBehaviour {

	string description;
	public Inventory inv;
	public Sprite icon;

	// Use this for initialization
	void Awake () {
		inv = GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Examine(){
		
	}
}
