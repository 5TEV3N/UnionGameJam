using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;



public class InventorySystem : MonoBehaviour {

   

    GameObject inventoryPanel;
    GameObject slotPanel;
    ItemDatabase database;
    public  GameObject inventorySlot;
    public GameObject inventoryItem;

    private int slotAmount;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    void Start()
    {
        database = GetComponent<ItemDatabase>();
        slotAmount = 10;
        inventoryPanel = GameObject.Find("Inventory Panel");
        slotPanel = inventoryPanel.transform.FindChild("Slot Panel").gameObject;
        for(int i = 0; i < slotAmount; i++)
        {
            items.Add(new Item());
            slots.Add(Instantiate(inventorySlot));
            slots[i].GetComponent<InventorySlot>().id = i;
            slots[i].transform.SetParent(slotPanel.transform);
        }

        AddItem(0);
        AddItem(1);
    }

    public void AddItem (int id)
    {
          Item itemToAdd = database.FetchItemByID(id);
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == -1)
            {
                items[i] = itemToAdd;
                GameObject itemObj = Instantiate(inventoryItem);
                itemObj.GetComponent<ItemData>().item = itemToAdd; // Connects with new script <ItemData>
                itemObj.GetComponent<ItemData>().slotLocation = i;
                itemObj.transform.SetParent(slots[i].transform);
                itemObj.transform.position = Vector2.zero;
                itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                itemObj.name = itemToAdd.Title;
                
                break;

                // https://www.youtube.com/watch?v=5itb0TryrGQ  time: 1:00 [Drag and Drop]
            }
        }
    }
}
