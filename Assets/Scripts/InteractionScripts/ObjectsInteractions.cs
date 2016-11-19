using UnityEngine;
using System.Collections;

public class ObjectsInteractions
{
    public string objectName;
    public int objectValue;
    public bool objectHeld;
    public GameObject objectInstance;
    public Transform objectPosition;


    //public void HighlightOnHover(){}   <--- Supposedly Ryon has the script that relates to these

    public void AddObjectToInventory(string name , int value, GameObject instance)
    {
        // Place object into your inventory
        objectName = name;
        objectValue = value;
        objectInstance = instance;
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
            if (key is pressed)
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
