using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
[System.Serializable]
public class InventorySystem : MonoBehaviour
{
//This is the refference script for the inventory
   

    GameObject inventoryPanel;
    GameObject slotPanel;
    //ItemDatabase database;
    public  GameObject inventorySlot;
    public GameObject inventoryItem;

    public int slotAmount;
    //public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();
    [SerializeField]
    public List<Objects> objectsFullList;
    public List<Objects> currentInventory;
    public Objects resetObject;

    void Start()
    {
        //database = GetComponent<ItemDatabase>();
        slotAmount = objectsFullList.Count;
        inventoryPanel = GameObject.Find("Inventory Panel");
        slotPanel = inventoryPanel.transform.FindChild("Slot Panel").gameObject;
        for(int i = 0; i < slotAmount; i++)
        {
            Objects temp = resetObject;
            currentInventory.Add(temp);
            slots.Add(Instantiate(inventorySlot));
            slots[i].GetComponent<InventorySlot>().id = i;
            slots[i].transform.SetParent(slotPanel.transform);
        }

        AddItem(0);
        AddItem(1);
    }

    public Objects FetchObjectByID(int id) {
        for (int i = 0; i < objectsFullList.Count; i++) {
            if (objectsFullList[i].objectVal.identityNumber == id) {
                return objectsFullList[i];
            }
        }
        return null;
    }
    public void AddItem (int id)
    {
        Objects itemToAdd = FetchObjectByID(id);
        for (int i = 0; i < currentInventory.Count; i++)
        {
            if (currentInventory[i].objectVal.identityNumber == id)
            {
                currentInventory[i] = itemToAdd;
                GameObject itemObj = Instantiate(inventoryItem);
                itemObj.GetComponent<ItemData>().item = itemToAdd; // Connects with new script <ItemData>
                itemObj.GetComponent<ItemData>().slotLocation = i;
                itemObj.transform.SetParent(slots[i].transform);
                itemObj.transform.position = Vector2.zero;
                itemObj.GetComponent<Image>().sprite = itemToAdd.objectVal.itemIcon;
                itemObj.name = itemToAdd.objectVal.itemName;
                
                break;

                // https://www.youtube.com/watch?v=5itb0TryrGQ  time: 1:00 [Drag and Drop]
            }
        }
    }

    //OLD INVENTORY SYSTEM
    //public Spawner InventoryItemSpawner;            //Spawner for EquipItem();
    //public ObjectsInteractions objectsToInvetory;
    //public GameObject itemToEquip;                  //Item from inventory to hold with EquipItem();
    //public Transform itemSpawnSpot;                 //Where the EquipItem will spawn;
    //public List<Objects> objectsFullList;
    ////Checking held items
    //public GameObject heldItem;

    //void Start()
    //{
    //    InventoryItemSpawner = new Spawner();
    //    objectsToInvetory = new ObjectsInteractions();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKey(KeyCode.E))
    //    {
    //        EquipInventoryItem(itemSpawnSpot, itemToEquip);
    //    }
    //}

    ////Inventory System


    ////Equip Item();

    //void EquipInventoryItem(Transform p_itemSpawnSpot, GameObject p_itemToEquip)
    //{
    //    InventoryItemSpawner.SpawnObjectAtSpot(p_itemSpawnSpot, p_itemToEquip);
    //    p_itemToEquip.transform.SetParent(itemSpawnSpot);
    //}

    //void DropHeldItem()
    //{
    //    //Until we know how to drop it, we are just setting the object Inactive;
    //    heldItem.SetActive(false);
    //    //until we can drop it, we reset the value;
    //    heldItem = null;
    //}

    ////UI system
    //void uiSystem()
    //{

    //}
}
