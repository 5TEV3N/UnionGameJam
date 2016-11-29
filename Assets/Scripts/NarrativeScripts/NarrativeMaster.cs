using UnityEngine;
using System.Collections;

public class NarrativeMaster : MonoBehaviour {

	public BasicNarrativeEngine narrativeManager;

	// Use this for initialization
	void Start () {
		narrativeManager = new BasicNarrativeEngine();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
