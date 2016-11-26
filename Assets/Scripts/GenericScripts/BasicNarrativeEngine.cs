using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicNarrativeEngine{

	public BasicNarrativeText currentNarrativeText;
	public BasicNarrativeText nextNarrativeText;
	public Dictionary <string,BasicNarrativeText> narrativeFullList;
	public Dictionary <int,BasicNarrativeText> narrativeSelectionHistory;
	public int narrativeIterationCount = 0;
	private int narrativeLayerInUse;

	//constructor
	public BasicNarrativeEngine(){
		
	}
	public void AddCurrentNarrativeTextToHistory(){
		currentNarrativeText.MarkTime ();
		narrativeSelectionHistory.Add (narrativeIterationCount, currentNarrativeText);
		//Until I figure out how to log the time wiht a data pair a debug log
		Debug.Log("You have just stored " + currentNarrativeText + " at index value" + narrativeIterationCount + " the current time is " + Time.time);
		narrativeIterationCount++;

	}
	public void AddNarrativeTextToList(string narrativeKeyName,BasicNarrativeText narrativeTextToAdd){
		BasicNarrativeText temp = null;
		if (narrativeFullList.TryGetValue(narrativeKeyName, out temp)){
			Debug.Log ("There is already an item with the stateID " + narrativeKeyName + " as a key");
		}else{
		}

		//Assign key to state;
		narrativeTextToAdd.keyName = narrativeKeyName;
		narrativeFullList.Add (narrativeKeyName, narrativeTextToAdd);
	}


}
