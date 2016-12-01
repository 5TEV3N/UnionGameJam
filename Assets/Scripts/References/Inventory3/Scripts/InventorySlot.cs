using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class InventorySlot : MonoBehaviour, IDropHandler {

    public int id;
    private InventorySystem inv;

    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<InventorySystem>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
        if (inv.items[id].ID == -1)
        {
            inv.items[droppedItem.slotLocation] = new Item();
            inv.items[id] = droppedItem.item;
            droppedItem.slotLocation = id;
        }
        else if(droppedItem.slotLocation != id)
        {
            Transform item = this.transform.GetChild(0);
            item.GetComponent<ItemData>().slotLocation = droppedItem.slotLocation;
            item.transform.SetParent(inv.slots[droppedItem.slotLocation].transform);
            item.transform.position = inv.slots[droppedItem.slotLocation].transform.position;

            droppedItem.slotLocation = id;
            droppedItem.transform.SetParent(this.transform);
            droppedItem.transform.position = this.transform.position;

            inv.items[droppedItem.slotLocation] = item.GetComponent<ItemData>().item;
            inv.items[id] = droppedItem.item;
        }
    }



}
