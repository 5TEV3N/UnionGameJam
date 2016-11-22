using UnityEngine;
using System.Collections;

public class ObjectsInteractions
{
    public string objectName;
    public int objectValue;
    public bool objectHeld;
    public GameObject objectInstance;
    public Transform objectPosition;

    private BasicItem gameItem = new BasicItem();

    //public void HighlightOnHover(){}   <--- Supposedly Ryon has the script that relates to these

    public void AddObjectToInventory(string p_name , int p_value, float p_weight)
    {
        // Place object into your inventory
        gameItem.itemName = p_name;
        gameItem.identityNumber = p_value;
        gameItem.itemWeight = p_weight;

    }

    public void HoldObject(GameObject instance, Transform position)
    {
        // Instantiate the object in this position
        objectInstance = instance;
        objectPosition = position;

        objectHeld = true;

        if (objectHeld == true)
        {
            /*
            if (Input.GetKeyDown(KeyCode.Q))
            {
                LeaveObject();
            }
            */
        }

    }
    
    public void LeaveObject()
    {
        //if holding an object is happening, you may drop that object
    }
}
