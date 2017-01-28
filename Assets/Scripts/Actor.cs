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
	public Inventory inventory;

	public Location residence, workplace;
	public List<Location> free_locations;
	public int work_shift, sleep_shift;

	private MainLog ml;
	private Actor _self;
	private TaskList taskList;
	public Intelligence intelligence;

	// Use this for initialization
	void Awake () {
		_self = GetComponent<Actor>();
		taskList = GetComponent<TaskList>();
		intelligence = GetComponent<Intelligence>();
		free_locations = new List<Location>();
		sprite = GetComponent<Sprite>();
		ml = MainLog.mainLog;
		dossier = Dossier.dossier;
		transform.name = name;
		inventory = GetComponent<Inventory>();
//		TurnManager.instance.step += TurnManager_instance_step;

		//remove this (placeholder)

//		free_locations.Add(GameObject.Find("Restaurant").GetComponent<Location>());

	}

	void Start(){
		Init_Intel();
		if(location != null){
			location.actors.Add(_self);
		}
	}

	void Update(){
		if(moving){
			transform.position = Vector2.Lerp(transform.position,endPos,Time.deltaTime*2);
			Debug.Log("moving");
			if(startPos == endPos){
				moving = false;
			}
		}

	}

	bool moving;
	Vector2 startPos;
	Vector2 endPos;

	public void SetLocation(Location loc){
		if(loc == location){
			return;
		}
		loc.AttachActor(_self);
		location = loc;
		startPos = transform.position;
		endPos = loc.transform.position + new Vector3(Random.Range(-1,1),
																  Random.Range(-1,1),
																  -.5f);
		moving = true;
	}

	public void OpenDossier(){
		dossier.Initialize(_self);
	}
		
	void TurnManager_instance_step ()
	{

		//routine placeholders

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
//		intelligence.AddIntel(new I_Residence(_self,location,_self));
//		intelligence.AddIntel(new I_Workplace(_self,workplace,_self,work_shift));
	}
}
