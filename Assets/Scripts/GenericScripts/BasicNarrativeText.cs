using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicNarrativeText{

	public string keyName;
	public string keyValue;
	public List<BasicTag> associatedTags;

	BasicNarrativeText(){
	}
	void SetNarrativeValue(string valueToSet){
		keyValue = valueToSet;
	}
	void SetKeyName(string keyToSet){
		keyName = keyToSet;
	}
	void AddTagToList(BasicTag tagToSet){
		associatedTags.Add (tagToSet);
	}
	List<BasicTag> GetAssociatedTags(){
		return associatedTags;
	}
	bool CheckIfTagIsInList (BasicTag tagToCheck){
		return associatedTags.Contains (tagToCheck);
	}

}
