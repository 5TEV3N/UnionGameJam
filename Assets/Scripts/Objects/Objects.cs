﻿using UnityEngine;
using System.Collections;
[System.Serializable]
public class Objects : MonoBehaviour
{
    //made these public so that the inventorySystem can use them
    public BasicItem objectVal = new BasicItem();
    public Spawner spawn = new Spawner();

	//PRototype START
	//public PrototypeEngine prototyper;

	//void Awake(){
	//	prototyper = GameObject.Find("GameMaster").GetComponent<PrototypeEngine>();
	//}


	//void OnTriggerEnter(Collider other){
	//	if (other.tag == "Player") {
	//		prototyper.DoNextThing(prototyper.startObjectiveText1,prototyper.starOldManText2);
	//	}
		
	//}

	//Prototype END
    public void SetObjectState()
    {

    }
    
    public void GetObjectState()
    {

    }

    public void DestroyGameObject(GameObject p_GameObjectInstance)
    {

    }

    public void InstantiateAtLocation(GameObject p_GameObjectInstance, Transform p_SpawnPoint)
    {
        spawn.SpawnObjectAtSpot(p_SpawnPoint, p_GameObjectInstance);
    }
}
