﻿using UnityEngine;
using System.Collections;

public class Spawner {

	//Variables

	public Spawner(){
	}

	public void SpawnAtStart(Transform[] objectSpawnLocations, GameObject objectToSpawn){
		for (int i = 0; i < objectSpawnLocations.Length; i++) { 
			GameObject newObjectToSpawn = GameObject.Instantiate (objectToSpawn);
			newObjectToSpawn.transform.position = objectSpawnLocations [i].position;
		}
	}
	public void SpawnObjectAtRandomLocation(int objectsToSpawnAtRandom, Transform[] objectSpawnLocations , GameObject objectToSpawn){
		for (int i = 0; i < objectsToSpawnAtRandom; i++) { 
			GameObject newObjectToSpawn = GameObject.Instantiate (objectToSpawn);
			newObjectToSpawn.transform.position = objectSpawnLocations [Random.Range (0, objectSpawnLocations.Length)].position;
		}
	}
	public void SpawnObjectAtSpot(Transform objectSpawnPlace, Transform[] objectSpawnLocations, GameObject objectToSpawn){
		GameObject newObjectToSpawn = GameObject.Instantiate (objectToSpawn);
		newObjectToSpawn.transform.position = objectSpawnPlace.position;
	}
}