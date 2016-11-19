using UnityEngine;
using System.Collections;

public class BasicState {

	public int stateID;
	public string stateName;
	public float timeMarker;
	//public 

	public BasicState(int p_stateID , string p_stateName){
		stateID = p_stateID;
		stateName = p_stateName;
	}
	public float MarkTime(){
		timeMarker = Time.time;
		return timeMarker;
	}

}
