using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicObjectiveEngine{

	public BasicObjective currentObjective;
	public BasicObjective nextObjective;
	public Dictionary <string,BasicObjective> objectiveFullList;
	public Dictionary <int,BasicObjective> objectiveHistory;
	public int objectiveIterationCount = 0;

	public BasicObjectiveEngine(){
	
	}
	public BasicObjective GetState(){
		return currentObjective; 
	}

	public void SetObjective(BasicObjective p_nextObjective = null){
		if (nextObjective == null && p_nextObjective == null) {
			Debug.Log ("SetState cannot complete the function as Next State and the argument parameter are null");
			return;
		}
		if (p_nextObjective == null) {
			p_nextObjective = nextObjective;
		}
		currentObjective = p_nextObjective;
		AddCurrentObjectiveToHistory ();

	}
	public bool CheckState(BasicObjective p_objectiveToCheck, BasicObjective p_checkAgainstObjective){
		p_objectiveToCheck = currentObjective;
		if (p_objectiveToCheck == p_checkAgainstObjective) {
			return true;
		} else {
			return false;
		}
	}
	public void SetObjectiveToNull(){
		currentObjective = null;
	}
	public void AddCurrentObjectiveToHistory(){
		currentObjective.MarkTime ();
		objectiveHistory.Add (objectiveIterationCount, currentObjective);
		//Until I figure out how to log the time wiht a data pair a debug log
		Debug.Log("You have just stored " + currentObjective + " at index value" + objectiveIterationCount + " the current time is " + Time.time);
		objectiveIterationCount++;

	}
	public void AddObjectiveToList(string objectiveName,BasicObjective objectiveToAdd){
		BasicObjective temp = null;
		if (objectiveFullList.TryGetValue(objectiveName, out temp)){
			Debug.Log ("There is already an item with the stateID " + objectiveName + " as a key");
		}else{
		}

		//Assign key to state;
		objectiveToAdd.objectiveName = objectiveName;
		objectiveFullList.Add (objectiveName, objectiveToAdd);
	}

}
