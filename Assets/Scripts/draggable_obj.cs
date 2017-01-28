using UnityEngine;
using System.Collections;

public class draggable_obj : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver(){
		bool click = Input.GetMouseButton(0);
		Vector3 v3 = Input.mousePosition;
		v3.y = 2;
		if(click){
			transform.position = Camera.main.ScreenToWorldPoint(v3);
		}
	}
}
