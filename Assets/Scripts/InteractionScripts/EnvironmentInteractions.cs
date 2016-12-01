using UnityEngine;
using System.Collections;

public class EnvironmentInteractions : MonoBehaviour {

	public GameObject objectToInteractWith;
	public bool valueToSet;
	public GameObject[] mastersList;
	public string masterToUse;
	public State stateToSet;
	public Objective objectiveToComplete;
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
				case "SetObj":
					//SetObjective ();
					break;
				case "SetState":
					break;
				case "SetBool":
				default:
					break;
				}
			}
		}
	}

	//SetObjective(Objective )
}
