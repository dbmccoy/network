using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Location : MonoBehaviour {

	public string name;

	public List<Actor> actors;

	private Location _self;

	// Use this for initialization
	void Awake () {
		actors = new List<Actor>();
		transform.name = name;
		_self = GetComponent<Location>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AttachActor(Actor actor){
		actors.Add(actor);
	}

	public void DetachActor(Actor actor){
		actors.Remove(actor);
	}

	void OnMouseOver(){
		if(Input.GetMouseButtonDown(1)){
			Dossier.dossier.Initialize(_self);
		}
	}
}
