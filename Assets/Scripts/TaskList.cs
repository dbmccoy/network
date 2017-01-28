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

		Location loc1,loc2,loc3;
		loc1 = actor.free_locations[0];
		if(actor.work_shift == 1)loc1 = actor.workplace;
		if(actor.sleep_shift == 1)loc1 = actor.residence;
		Debug.Log(actor.name + ": loc1 = " + loc1);

		loc2 = actor.free_locations[0];
		if(actor.work_shift == 2)loc2 = actor.workplace;
		if(actor.sleep_shift == 2)loc2 = actor.residence;
		Debug.Log(actor.name + ": loc2 = " + loc2);

		loc3 = actor.free_locations[0];
		if(actor.work_shift == 3)loc3 = actor.workplace;
		if(actor.sleep_shift == 3)loc3 = actor.residence;
		Debug.Log(actor.name + ": loc3 = " + loc3);

		if(phase == 1){
			return loc1;
		}
		if(phase == 2){
			return loc2;
		}
		if(phase == 3){
			return loc3;
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
		//actor.location = location;
		actor.SetLocation(location);
		//actor.transform.position = location.transform.position + new Vector3(Random.Range(-1,1),
		//																	 Random.Range(-1,1),
		///																	 -.5f);
		Debug.Log(actor.name +" moved to "+ location.name);
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
		//Debug.Log(actor.name + " waiting");
		Actor[] local_actors = location.actors.ToArray();
		foreach (var item in local_actors) {
			//Debug.Log(item.name + " is here");
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

public class EvaluateActor : Ability{
	public Actor actor; public Actor t_actor; public Location location;

	public EvaluateActor(Actor _actor, Actor t_actor, Intel _intel){
		actor = _actor; this.t_actor = t_actor; location = actor.location;
	}

	public override void Do(){
		if(location == t_actor.location){
			var inv = t_actor.intelligence.inv;
			Intel intel = inv[Random.Range(0,inv.Count)];
			actor.intelligence.AddIntel(intel);
		}
	}
}

