using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Intelligence : MonoBehaviour {

	public List<Intel> inv;
	private Actor actor;

	// Use this for initialization
	void Awake () {
		inv = new List<Intel>();
		actor = GetComponent<Actor>();
	}

	public void AddIntel(Intel _intel){
		inv.Add(_intel);
		Debug.Log(_intel.Read());
	}

	public Actor GetActor(){
		return actor;
	}
}

public class Intel{
	public Intel(){
		
	}

	public virtual string Read(){
		return "base class value";
	}

	public virtual void Query(){
		
	}
}

public class I_Residence : Intel{
	public Actor actor, t_actor; public Location location;

	public I_Residence(Actor _actor, Location _location, Actor t_actor){
		actor = _actor; this.t_actor = t_actor; location = _location;
	}

	public override string Read(){
		string s = actor.name + ": " + t_actor.name + " lives at " + location.name;
		return s;
	}

	public override void Query(){
		
	}
}

public class I_Workplace : Intel{
	public Actor actor, t_actor; public Location location; int shift;

	public I_Workplace(Actor _actor, Location _location, Actor t_actor, int _shift){
		actor = _actor; this.t_actor = t_actor; location = _location; shift = _shift;
	}

	public override string Read(){
		string s = actor.name + ": " + t_actor.name + " works at " + location.name + ", shift " + shift;
		return s;
	}

	public override void Query(){

	}
}

