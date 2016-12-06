using UnityEngine;
using System.Collections;

public class EnvironmentTextAfterTime : MonoBehaviour {

	public NarrativeEngine narrativeEngine;
	public bool onTriggerEnter;
	public bool onTriggerExit;
	public bool onTriggerStay;
	public int narrativeLayer;
	public string narrativeKey;
	public bool t4Layerf4Key;

	void Awake(){
		
	}

	void OnTriggerEnter(Collider other){
		if (onTriggerEnter == true) {
		
		}
	}
	void OnTriggerStay(Collider other){
		if (onTriggerStay == true) {

		}
	}
	void OnTriggerExity(Collider other){
		if (onTriggerExit == true) {

		}
	}
}
