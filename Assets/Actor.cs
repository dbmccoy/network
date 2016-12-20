using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Actor : MonoBehaviour {

	public string name;
	public Sprite sprite;
	//Affiliation
	public bool can_request;
	public string nationality;
	public Location location;
	public Dossier dossier;

	public Location residence, workplace;

	private MainLog ml;
	private Actor _self;
	private TaskList taskList;
	public Intelligence intelligence;

	// Use this for initialization
	void Awake () {
		_self = GetComponent<Actor>();
		taskList = GetComponent<TaskList>();
		intelligence = GetComponent<Intelligence>();
		sprite = GetComponent<Sprite>();
		ml = MainLog.mainLog;
		dossier = Dossier.dossier;
		transform.name = name;
		TurnManager.instance.step += TurnManager_instance_step;

	}

	void Start(){
		Init_Intel();
		if(location != null){
			location.actors.Add(_self);
		}
	}

	public void SetLocation(Location loc){
		if(loc == location){
			return;
		}
		loc.AttachActor(_self);
		location = loc;

		transform.position = loc.transform.position + new Vector3(Random.Range(-1,1),
																  Random.Range(-1,1),
																  -.5f);
		Logger.newLog(GetComponent<Actor>(),location,"arrived at "+location.name);
	}

	public void OpenDossier(){
		dossier.Initialize(_self);
	}
		
	void TurnManager_instance_step ()
	{

		if(taskList.GetListLength(taskList.moveQueue)==0){
			MoveToLocation NextLocation = new MoveToLocation(_self,taskList.NextLocation());
			NextLocation.Do();
		}

		// add intel test code
		/*if(taskList.GetListLength()==0 && location.actors.Count > 1){
			var t_actor = from a in location.actors where a != _self select a;
			taskList.AddTask(new TransferIntelLocal(_self,t_actor.FirstOrDefault(),intelligence.inv[0],location));
			taskList.ExecuteTask();
		}*/
	}

	public void test(params object[] args){
		for (int i = 0; i < args.Length; i++) {
			Debug.Log(args[i]);
		}
	}

	void Init_Intel(){
		intelligence.AddIntel(new I_Residence(_self,location,_self));
	}
}
