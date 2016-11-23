using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BasicObjective{

	public int identityNumber;
	public string objectiveName;
	public string objectiveMessage;
	public float timeMarker;
	public float timeOfOnset;

	//public 

	public BasicObjective(int p_identityNumber , string p_objectiveName, float timeStart = 0){
		identityNumber = p_identityNumber;
		objectiveName = p_objectiveName;
		timeOfOnset = MarkTime ();
	}
	public float MarkTime(){
			timeMarker = Time.time;
			return timeMarker;
	}
	public void SetObjectiveMessage(string objectiveMessageToSet){
		objectiveMessage = objectiveMessageToSet;
	}
	public string GetObjectiveMessage(){
		return objectiveMessage;
	}
	public bool CheckObjectiveMessage(string objectiveMessageToCheck){
		if (objectiveMessageToCheck == objectiveMessage) {
			return true;
		} else {
			return false;
		}
	}

}
