using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TaskList : MonoBehaviour {

	public List<Ability> tasks;
	public List<Ability> moveQueue;
	private Actor actor;

	// Use this for initialization
	void Awake () {
		tasks = new List<Ability>();
		moveQueue = new List<Ability>();
	}

	void Start(){
		actor = GetComponent<Actor>();
	}

	public void AddTask(Ability _task){
		tasks.Add(_task);
	}

	public void AddMove(Ability _move){
		moveQueue.Add(_move);
	}

	public void ExecuteMove(int i = 0, bool recycle = false){
		moveQueue[i].Do();
		if(recycle){
			RecycleMove(i);
		}
	}

	public void RecycleMove(int i = 0){
		Ability move1 = moveQueue[i];
		moveQueue.RemoveAt(i);
		moveQueue.Add(move1);
	}

	public void ExecuteTask(int i = 0){
		tasks[i].Do();
		tasks.Remove(tasks[i]);
	}

	public int GetListLength(List<Ability> list){
		return list.Count;
	}

	// Routine

	public Location NextLocation(){
		int phase = TurnManager.instance.time;
		if(phase == 1){
			return actor.workplace;
		}
		if(phase == 2){
			return actor.residence;
		}
		if(phase == 3){
			return actor.residence;
		}
		else{
			return actor.location;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

public class Ability{

	public Actor actor;

	public Ability(){
	}
	public virtual void Do(){
		
	}
}
	

public class MoveToLocation : Ability{
	public Location location;
	public Actor actor;

	public MoveToLocation(Actor _actor,Location _location){
		this.location = _location;
		this.actor = _actor;
	}

	public override void Do(){
		if(location == actor.location) return;
		location.AttachActor(actor);
		actor.location = location;
		actor.transform.position = location.transform.position + new Vector3(Random.Range(-1,1),
																			 Random.Range(-1,1),
																			 -.5f);
		Debug.Log(actor.name +" is moving to "+ location.name);
	}
}

public class Wait : Ability{
	public Location location;
	public Actor actor;

	public Wait(Actor _actor){
		this.actor = _actor;
		this.location = actor.location;
	}

	public override void Do(){
		Debug.Log(actor.name + " waiting");
		Actor[] local_actors = location.actors.ToArray();
		foreach (var item in local_actors) {
			Debug.Log(item.name + " is here");
		}
	}
}

public class TransferIntelLocal : Ability{
	public Actor actor; public Actor t_actor; Intel intel; public Location location;

	public TransferIntelLocal(Actor _actor, Actor t_actor, Intel _intel, Location _location){
		actor = _actor; this.t_actor = t_actor; intel = _intel; location = _location;
	}

	public override void Do(){
		t_actor.intelligence.AddIntel(intel);
	}
}

