using UnityEngine;
using System.Collections;

public class InventorySystem : MonoBehaviour {

	//Variables


	public Spawner InventoryItemSpawner; //Spawner for EquipItem();
	public GameObject itemToEquip; //Item from inventory to hold with EquipItem();
	public Transform itemSpawnSpot; //Where the EquipItem will spawn;

	//Checking held items
	public GameObject heldItem;

	// Use this for initialization
	void Start () {
		InventoryItemSpawner = new Spawner();
	
	}
	
	// Update is called once per frame
	void Update () {
	
//		if (Input.GetKey(KeyCode.E)){
//			EquipInventoryItem (itemSpawnSpot, itemToEquip);
//		}

	}

	//Inventory System


	//Equip Item();

	void EquipInventoryItem (Transform p_itemSpawnSpot, GameObject p_itemToEquip){
		InventoryItemSpawner.SpawnObjectAtSpot (p_itemSpawnSpot, p_itemToEquip);
		p_itemToEquip.transform.SetParent (itemSpawnSpot);

	}
	void DropHeldItem(){
		//Until we know how to drop it, we are just setting the object Inactive;
		heldItem.SetActive(false);
		//until we can drop it, we reset the value;
		heldItem = null;
	}

	//UI system
}
