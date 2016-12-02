using UnityEngine;
using System.Collections;

public class GameEngine : MonoBehaviour {

   //Redundant public State g_EngineState;
	public BasicObjectiveEngine gameObjectiveEngine = new BasicObjectiveEngine();
	public BasicStateEngine gameStateEngine = new BasicStateEngine();
	public UIEngine uiEngine;
	public NarrativeEngine narrativeEngine;
	public GameObject[] listOfTriggers;

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

		//Start Win/Lose
			if (gameObjectiveEngine.objectiveFullList[0] == gameObjectiveEngine.currentObjective) {
				//uiEngine.DisplayNarrativeText (gameObjectiveEngine.currentObjective.thisObjective.objectiveMessage);

				WinGame ();

			}
			if(GameObject.FindWithTag("Player").GetComponent<PlayerController>().playerHealth.baseAttributeCurrent <= 0){
				LoseGame ();
			}
			if (gameObjectiveEngine.objectiveFullList[1] == gameObjectiveEngine.currentObjective) {
				//uiEngine.DisplayNarrativeText (gameObjectiveEngine.currentObjective.thisObjective.objectiveMessage);

				LoseGame ();
			}
		//End Win/Lose

		//Start Objective Progresses
			//Objective 1 Enter house
			if (gameObjectiveEngine.objectiveFullList[2] == gameObjectiveEngine.currentObjective) {
				uiEngine.DisplayNarrativeText (narrativeEngine.narrativeManager.GetHeaviestNarrativeKey (10).narrativeObject.keyValue);


			}
			//Objective 2 See Old Man
			if (gameObjectiveEngine.objectiveFullList[3] == gameObjectiveEngine.currentObjective) {
				uiEngine.DisplayNarrativeText (narrativeEngine.narrativeManager.GetHeaviestNarrativeKey (11).narrativeObject.keyValue);

				GameObject.Find ("TZOM11").GetComponent<BoxCollider>().enabled = false;
				GameObject.Find ("TZOM13").GetComponent<BoxCollider>().enabled = true;

			}
			//Objective 3 Get ScrapBook
			if (gameObjectiveEngine.objectiveFullList[4] == gameObjectiveEngine.currentObjective) {
				uiEngine.DisplayNarrativeText (narrativeEngine.narrativeManager.GetHeaviestNarrativeKey (12).narrativeObject.keyValue);
				GameObject.Find ("TZOM13").GetComponent<BoxCollider>().enabled = false;
				GameObject.Find ("TZOM14").GetComponent<Renderer>().enabled = true;
				GameObject.Find ("TZOM14").GetComponent<BoxCollider>().enabled = true;

			}
			//Objective 4 Feel the scrap book
			if (gameObjectiveEngine.objectiveFullList[5] == gameObjectiveEngine.currentObjective) {
				uiEngine.DisplayNarrativeText (narrativeEngine.narrativeManager.GetHeaviestNarrativeKey (13).narrativeObject.keyValue);
				GameObject.Find ("TZOM14").GetComponent<Renderer>().enabled = false;
				GameObject.Find ("NOScrapBook").GetComponent<Renderer>().enabled = false;
				GameObject.Find ("TZOM15").GetComponent<BoxCollider>().enabled = true;

			}
			//Objective 5 Give it to Old Man
			if (gameObjectiveEngine.objectiveFullList[6] == gameObjectiveEngine.currentObjective) {
				uiEngine.DisplayNarrativeText (narrativeEngine.narrativeManager.GetHeaviestNarrativeKey (14).narrativeObject.keyValue);
				
				GameObject.Find ("TZOM14").GetComponent<BoxCollider>().enabled = false;
				GameObject.Find ("TZOM14").GetComponent<Renderer>().enabled = false;
				GameObject.Find ("NOScrapBook").GetComponent<Renderer>().enabled = false;


			}
		//End Objective Progresses
		//Start State Conditions
			if (gameStateEngine.stateFullList[0] == gameStateEngine.currentState){
				GameObject.Find ("Lvl1cube").GetComponent<Renderer>().enabled = true;
				

			}
			if (gameStateEngine.stateFullList[1] == gameStateEngine.currentState){
				GameObject.Find ("Lvl2cube").GetComponent<Renderer>().enabled = true;
				GameObject.Find ("Lvl1cube").GetComponent<Renderer>().enabled = false;
			}
			
		//EndStateConditions

	}

}
