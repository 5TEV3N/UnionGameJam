﻿using UnityEngine;
using System.Collections;

public class NarrativeEngine : MonoBehaviour {


    public BasicNarrativeEngine narrativeManager;
    public State n_EngineState;
    public BasicStateEngine narrativeStateEngine = new BasicStateEngine();
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