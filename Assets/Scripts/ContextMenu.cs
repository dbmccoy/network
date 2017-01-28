using UnityEngine;
using System.Collections;

public class ContextMenu : MonoBehaviour {

	private Actor actor;
	private Obj obj;
	private GameObject panel_actor;
	private GameObject panel_obj;

	public enum Command{
		none,
		move_directive,
		examine
	}

	public Command command;

	private static ContextMenu _menu;
	public static ContextMenu menu{
		get {
			if(_menu == null){
				_menu = GameObject.Find("ContextMenu").GetComponent<ContextMenu>();
			}

			return _menu;
		}
	}

	// Use this for initialization
	void Awake () {
		panel_actor = transform.FindChild("panel_actor").gameObject;
		panel_obj = transform.FindChild("panel_obj").gameObject;
	}

	void Start(){
		actor = GameObject.Find("Player").GetComponent<Actor>();
	}
	
	// Update is called once per frame
	void Update () {
		bool click = Input.GetMouseButtonDown(0);
		if(command == Command.move_directive){
			if(click && Mouse.mouse.hovering.mouse_type == Mouse.Mode.Location){
				Location _location = Mouse.mouse.hovering.GetComponent<Location>();
				//actor.SetLocation();
				actor.GetComponent<TaskList>().AddTask(new MoveToLocation(actor,_location));
				command = Command.none;
				Debug.Log("fix this shitty code immediately!");
			}
		}
	}

	public void SetActor(Actor a){
		actor = a;
		Debug.Log("set actor to "+a.name);
		panel_actor.SetActive(true);
	}

	public void SetObj(Obj o){
		obj = o;
		Debug.Log("set obj to "+o.name);
		panel_obj.SetActive(true);
	}

	public void MoveDirective(){
		command = Command.move_directive;
	}

	public void Examine(){
		command = Command.examine;
		Debug.Log("examining "+obj.name);

	}
}