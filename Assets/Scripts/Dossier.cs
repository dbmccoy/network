using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dossier : MonoBehaviour {

	//Actor Screen
	public Actor actor;
	public Text actor_name;
	public Location actor_location;
	public Text actor_location_name;
	public Text actor_log;

	//Location Screen
	public Location location;
	public Text location_name;
	public Text location_log;
	public Actor[] location_actors;


	private GameObject panel_actor;
	private GameObject panel_location;
	private static Dossier _dossier;

	public static Dossier dossier{
		get{
			if(_dossier == null){
				_dossier = GameObject.Find("Dossier").GetComponent<Dossier>();
			}

			return _dossier;
		}
	}


	// Use this for initialization
	void Awake () {
//		panel_actor = transform.FindChild("panel_actor").gameObject;
//		panel_location = transform.FindChild("panel_location").gameObject;
	}

	public void Initialize(Actor _actor){
		actor = _actor;
		actor_name.text = _actor.name;
		actor_location = _actor.location;
		if(actor_location == null){
			actor_location_name.text = "none";
		}
		else{
			actor_location_name.text = actor_location.name;
		}
		panel_location.SetActive(false);
		panel_actor.SetActive(true);
	}

	public void Initialize(Location _location){
		location_name.text = _location.name;
		//location_actors = _location.actors; list to array
		panel_actor.SetActive(false);
		panel_location.SetActive(true);
	}

}
