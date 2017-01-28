using UnityEngine;
using System.Collections;
using System;

public class TogglePanelButton : MonoBehaviour {

	public void TogglePanel(GameObject panel){
		panel.SetActive(!panel.activeSelf);
	}

	public void SetMouseMode(string m){
		Mouse.Mode mode = (Mouse.Mode) Enum.Parse(typeof(Mouse.Mode),m);
		Mouse.mouse.SetMode(mode);
	}

	public void MoveDirective(){
		
	}
}
