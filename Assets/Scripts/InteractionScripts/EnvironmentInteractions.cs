using UnityEngine;
using System.Collections;

public class EnvironmentInteractions : MonoBehaviour {

	public GameObject objectToInteractWith;
	public bool valueToSet;
	public GameObject[] mastersList;
	public GameObject masterToUse;
	public State stateToSet;
	public Objective objectiveToSet;
	public string commandToUse;
	public bool onTriggerEnter;
	public bool onTriggerExit;
	public bool onTriggerStay;
	//SetObj
	//SetState
	//SetBool

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (onTriggerEnter == true) {
			if (other == objectToInteractWith) {
				switch (commandToUse) {
				case "SetObjective":
					SetObjective ();
					break;
				case "SetState":
					SetState ();
					break;
				case "SetBool":
					SetBool ();
					break;
				default:
					break;
				}
			}
		}
	}
	void OnTriggerExit(Collider other){
		if (onTriggerExit == true) {
			if (other == objectToInteractWith) {
				switch (commandToUse) {
				case "SetObjective":
					SetObjective ();
					break;
				case "SetState":
					SetState ();
					break;
				case "SetBool":
					SetBool ();
					break;
				default:
					break;
				}
			}
		}
	}
	void OnTriggerStay(Collider other){
		if (onTriggerStay == true) {
			if (other == objectToInteractWith) {
				switch (commandToUse) {
				case "SetObjective":
					SetObjective ();
					break;
				case "SetState":
					SetState ();
					break;
				case "SetBool":
					SetBool ();
					break;
				default:
					break;
				}
			}
		}
	}

	public void SetObjective()
	{
		masterToUse.GetComponent<GameEngine> ().gameObjectiveEngine.SetObjective (objectiveToSet);
	}
	public void SetState(){
		if (masterToUse.name == "NarrativeMaster") {
			masterToUse.GetComponent<NarrativeEngine> ().narrativeStateEngine.SetState (stateToSet);
		}
		if (masterToUse.name == "UIMaster") {
			masterToUse.GetComponent<UIEngine> ().uiStateEngine.SetState (stateToSet);
		}
		if (masterToUse.name == "GameMaster") {
			masterToUse.GetComponent<GameEngine> ().gameStateEngine.SetState (stateToSet);
		}
		else{
			Debug.Log("There was not a master set to inherit a state");
		}
		
	}
	public void SetBool(){
		valueToSet = true;
	}
}
