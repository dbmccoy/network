using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

	public Clickable hovering;
	public Vector3 pos;

	public enum Mode{
		Location,
		Actor,
		Obj,
		Draggable
	}

	private Mode mode;

	private static Mouse _mouse;

	public static Mouse mouse {
		get {
			if(_mouse == null){
				_mouse = GameObject.Find("GameController").GetComponent<Mouse>();
			}

			return _mouse;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		pos = Input.mousePosition;
		pos = Camera.main.ScreenToWorldPoint(pos);
		pos.y = 0;
	}

	public void SetMode(Mode m){
		mode = m;
		Debug.Log("set mouse mode to "+m.ToString());
	}

	public void SetHover(Clickable c){
		//if(c.mouse_type == mode){
			hovering = c;
		//}
	}

	public void Click(Clickable c){
		Debug.Log("clicked "+c.name);
	}

}
