using UnityEngine;
using System.Collections;

public class Logger {

	public static Log newLog(Actor actor, Location location, string text){

		Log _log = new Log();
		_log.actor = actor;
		_log.location = location;
		_log.text = actor.name + ", " + location.name + ": " + text;
		MainLog.mainLog.EnterLog(_log);	

		return _log;
	}

}
