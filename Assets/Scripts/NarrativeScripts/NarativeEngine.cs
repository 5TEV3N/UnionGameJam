using UnityEngine;
using System.Collections;

public class NarativeEngine : MonoBehaviour {


    public BasicNarrativeEngine narrativeManager;
    public State n_EngineState;
    BasicTimer timerToUse;
    public float timerTime;
    public bool goTimer;
    // Use this for initialization
    void Start () {
        timerToUse = new BasicTimer(0f);

    }
	
	// Update is called once per frame
	void Update () {
	//narrativeManager.
	}
}
