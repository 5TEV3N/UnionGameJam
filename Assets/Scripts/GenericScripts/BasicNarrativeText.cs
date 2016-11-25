using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicNarrativeText{

	public string keyName;
	public string keyValue;
	public List<BasicTag> associatedTags;
	public float narrativeWeight;

	public BasicNarrativeText(){
	}
	public void SetNarrativeValue(string valueToSet){
		keyValue = valueToSet;
	}
	public void SetKeyName(string keyToSet){
		keyName = keyToSet;
	}
	public void SetNarrativeWeight(float weightToAssign){
		narrativeWeight = weightToAssign;
	}
	public float GetNarrativeWeight(){
		return narrativeWeight;
	}
	public void AddTagToList(BasicTag tagToSet){
		associatedTags.Add (tagToSet);
	}
	public List<BasicTag> GetAssociatedTags(){
		return associatedTags;
	}
	public bool CheckIfTagIsInList (BasicTag tagToCheck){
		return associatedTags.Contains (tagToCheck);
	}

}
