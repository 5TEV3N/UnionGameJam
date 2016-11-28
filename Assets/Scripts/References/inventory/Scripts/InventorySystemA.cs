using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;



public class InventorySystemA : MonoBehaviour {

   

    GameObject inventoryPanel;
    GameObject slotPanel;
    ItemDatabase database;
    public  GameObject inventorySlot;
    public GameObject inventoryItem;

    private int slotAmount;
    public List<Objects> items = new List<Objects>();
    public List<GameObject> slots = new List<GameObject>();

    void Start()
    {
        database = GetComponent<ItemDatabase>();
        slotAmount = 10;
        inventoryPanel = GameObject.Find("Inventory Panel");
        slotPanel = inventoryPanel.transform.FindChild("Slot Panel").gameObject;

        //Debug.Log(slotPanel.name + " is this different from" + inventoryPanel.transform.FindChild("Slot Panel").gameObject.name);
        for(int i = 0; i < slotAmount; i++)
        {
            items.Add(new Objects());
            // items.Add(new Objects(0, "bon",0, "equip"));
            slots.Add(Instantiate(inventorySlot));
            slots[i].transform.SetParent(slotPanel.transform);
        }

        //AddItem(0);
        //AddItem(1);
    }

    public void AddItem (int id)
    {
        Objects itemToAdd = database.FetchItemByID(id);
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].objectVal.identityNumber == -1)
            {
                items[i] = itemToAdd;
                GameObject itemObj = Instantiate(inventoryItem);
                itemObj.transform.SetParent(slots[i].transform);
                itemObj.transform.position = Vector2.zero;
                itemObj.GetComponent<Image>().sprite = itemToAdd.objectVal.itemIcon;
                itemObj.name = itemToAdd.objectVal.itemName;
                
                break;

                // https://www.youtube.com/watch?v=5itb0TryrGQ  time: 1:00 [Drag and Drop]
            }
        }
    }
}
