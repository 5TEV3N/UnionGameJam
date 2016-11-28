using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
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
    public BasicNarrativeText GetHeaviestNarrativeKey(int narrativeLayer, Dictionary<string,BasicNarrativeText> dictionaryToCheck) {
        BasicNarrativeText winningText = null;
        float highestWeight = 0;
        foreach (BasicNarrativeText myText in dictionaryToCheck.Values) {
            if (myText.narrativeLayer == narrativeLayer) {
                if (myText.narrativeWeight < highestWeight)
                {
                    winningText = myText;
                    highestWeight = myText.narrativeWeight;
             
                }

            }
        }
        return winningText;
    }

}
