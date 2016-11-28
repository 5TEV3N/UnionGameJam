using UnityEngine;
using System.Collections;
[System.Serializable]
public class BasicState {

	public int stateID;
	public string stateName;
	public float timeMarker;
	public float timeOfOnset;
	//public 

	public BasicState(int p_stateID , string p_stateName, float timeStart = 0){
		stateID = p_stateID;
		stateName = p_stateName;
		timeOfOnset = MarkTime ();
	}
	public float MarkTime(){
		timeMarker = Time.time;
		return timeMarker;
	}

}
