﻿using UnityEngine;
using System.Collections;

public class NarrativeMaster : MonoBehaviour {

	public BasicNarrativeObjectEngine narrativeManager;

	// Use this for initialization
	void Start () {
		narrativeManager = new BasicNarrativeObjectEngine();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
