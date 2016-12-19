using UnityEngine;
using System.Collections;

public class DragIcon : MonoBehaviour {

	private Actor actor;
	private Vector3 origin;
	private Vector3 mouseOrigin;
	private bool is_dragging;
	public Location hovering_over;
	float depth;


	// Use this for initialization
	void Start () {
		actor = GetComponent<Actor>();
		origin = transform.position;
		depth = transform.position.y + 8f;
	}
	
	// Update is called once per frame
	void Update () {
		if(is_dragging){
			if(Input.GetMouseButton(0)){
				Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				transform.position = transform.position - (mouseOrigin - pos);
				mouseOrigin = pos;
			}
			if(Input.GetMouseButtonUp(0)){
				is_dragging = false;
				if(hovering_over){
					actor.SetLocation(hovering_over);
				}
			}
		}
			

	}

	void OnMouseOver(){
		if(Input.GetMouseButtonDown(0)){
			if(actor.can_request){
				mouseOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				is_dragging = true;
			}
		}
		if(Input.GetMouseButtonDown(1)){
			actor.OpenDossier();
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if(is_dragging){
			hovering_over = other.GetComponent<Location>();
		}
	}

	void OnTriggerExit2D(Collider2D other){
		hovering_over = null;
	}
}
