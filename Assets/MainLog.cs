using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MainLog : MonoBehaviour {

	private List<Log> logs;
	public Text log_text;

	private static MainLog _mainLog;

	public static MainLog mainLog{
		get {
			if(_mainLog == null){
				_mainLog = GameObject.Find("LogPanel_Main").GetComponent<MainLog>();		
			}

			return _mainLog;
		}
	}

	public void EnterLog(Log _log){
		logs.Add(_log);
		UpdateLog();
		Debug.Log("added log");
	}

	// Use this for initialization
	void Start () {
		logs = new List<Log>();
	}

	void UpdateLog () {
		for (int i = 0; i < logs.Count; i++) {
			log_text.text = log_text.text + logs[i].text;
		}
	}
}
