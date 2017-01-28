using UnityEngine;
using System.Collections;

public class Clickable : MonoBehaviour {

	private Mouse mouse;
	private Clickable _self;

	public Mouse.Mode mouse_type;

	// Use this for initialization

	void Awake(){
		_self = GetComponent<Clickable>();
	}
	void Start () {
		mouse = Mouse.mouse;

	}
	
	// Update is called once per frame
	void OnMouseOver(){
		mouse.SetHover(_self);
	}

	void OnMouseDown(){
		bool click = Input.GetMouseButtonDown(0);
		if(click){
			if(mouse_type == Mouse.Mode.Actor){
				ContextMenu.menu.SetActor(GetComponent<Actor>());
			}
			if(mouse_type == Mouse.Mode.Obj){
				ContextMenu.menu.SetObj(GetComponent<Obj>());
			}
		}

	}
}
