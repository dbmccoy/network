using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour {

	public int day;
	public int time;

	public Text dayText;
	public Text timeText;

	private static TurnManager _instance;
	public static TurnManager instance{
		get{
			if(_instance == null){
				_instance = GameObject.FindObjectOfType<TurnManager>();
			}

			return _instance;
		}
	}

	public delegate void OnTimeStep();
	public event OnTimeStep step;

	// Use this for initialization
	void Start () {
		day = 1;
		time = 1;

		//TimeStep();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Advance")){
			TimeStep();
		}
	}

	public void TimeStep(){
		if(time == 6){
			day++;
			time = 1;
		}
		else{
			time++;
		}
		dayText.text = "Time: " + time;
		timeText.text = "Day " + day;

		step();
	}
}
