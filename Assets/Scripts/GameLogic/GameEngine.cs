using UnityEngine;
using System.Collections;

public class GameEngine : MonoBehaviour {

   //Redundant public State g_EngineState;
	public BasicObjectiveEngine gameObjectiveEngine = new BasicObjectiveEngine();
	public BasicStateEngine gameStateEngine = new BasicStateEngine();
	public UIEngine uiEngine;
	public NarrativeEngine narrativeEngine;


	//public 

	// Use this for initialization
	void Start () {
		uiEngine = GameObject.Find ("UIMaster").GetComponent<UIEngine> ();
		narrativeEngine = GameObject.Find ("NarrativeMaster").GetComponent<NarrativeEngine> ();

    }
	void WinGame(){
		
		string winMessage = narrativeEngine.narrativeManager.GetHeaviestNarrativeKey (3).narrativeObject.keyValue;

		uiEngine.DisplayNarrativeText (winMessage);
		Time.timeScale = 0;

	}

	void LoseGame(){
		string loseMessage = narrativeEngine.narrativeManager.GetHeaviestNarrativeKey (4).narrativeObject.keyValue;

		uiEngine.DisplayNarrativeText (loseMessage);
		Time.timeScale = 0;
	
	}


	// Update is called once per frame
	void Update () {

		//FirstObjective
		if (gameObjectiveEngine.objectiveFullList[0] == gameObjectiveEngine.currentObjective) {
			//uiEngine.DisplayNarrativeText (gameObjectiveEngine.currentObjective.thisObjective.objectiveMessage);

			//WinGame ();
			LoseGame ();
		}
	

	}

}
