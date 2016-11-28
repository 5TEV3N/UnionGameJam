using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class BasicStateEngine {

	public BasicState currentState;
	public BasicState nextState;
	public Dictionary <string,BasicState> stateFullList;
	public Dictionary <int,BasicState> stateHistory;
	public int stateIterationCount = 0;

	public BasicStateEngine(){
	}

	public BasicState GetState(){
		return currentState; 
	}

	public void SetState(BasicState p_nextState = null){
		if (nextState == null && p_nextState == null) {
			Debug.Log ("SetState cannot complete the function as Next State and the argument parameter are null");
			return;
		}
		if (p_nextState == null) {
			p_nextState = nextState;
		}
		currentState = p_nextState;
		AddCurrentStateToHistory ();

	}
	public bool CheckState(BasicState p_stateToCheck, BasicState p_checkAgainstState){
		p_stateToCheck = currentState;
		if (p_stateToCheck == p_checkAgainstState) {
			return true;
		} else {
			return false;
		}
	}
	public void SetStateToNull(){
		currentState = null;
	}
	public void AddCurrentStateToHistory(){
		currentState.MarkTime ();
		stateHistory.Add (stateIterationCount, currentState);
		//Until I figure out how to log the time wiht a data pair a debug log
		Debug.Log("You have just stored " + currentState + " at index value" + stateIterationCount + " the current time is " + Time.time);
		stateIterationCount++;

	}
	public void AddStateToList(string stateName,BasicState stateToAdd){
		BasicState temp = null;
		if (stateFullList.TryGetValue(stateName, out temp)){
			Debug.Log ("There is already an item with the stateID " + stateName + " as a key");
		}else{
		}

		//Assign key to state;
		stateToAdd.stateName = stateName;
		stateFullList.Add (stateName, stateToAdd);
	}
}
