using UnityEngine;
using System.Collections;

public class ObjectsInteractions
{
    public GameObject objectInstance;
    public Transform objectPosition;
    public bool isHighlighted;

    public Color orginalColor;
    public Renderer interactableObjRender;
    public GameObject interactableObj;


    private BasicItem gameItem = new BasicItem();

    public void HighlightOnHover(GameObject p_thisGameObject, Renderer p_interactableObjRender, Color p_objOriginalColor) //, Renderer p_interactableObjRender, Color p_objOriginalColor
    {
       orginalColor = p_objOriginalColor;
       interactableObjRender = p_interactableObjRender;
       interactableObj = p_thisGameObject;

       interactableObjRender = interactableObj.GetComponent<Renderer>();
       orginalColor = interactableObjRender.material.color;

        if (isHighlighted == true)
        {
            interactableObjRender.material.color = orginalColor + new Color32(200, 200, 200, 1);
        }

        if (isHighlighted == false)
        {
            interactableObjRender.material.color = orginalColor;
        }
    }


    public void AddObjectToInventory(string p_name , int p_value, float p_weight)
    {
        gameItem.itemName = p_name;
        gameItem.identityNumber = p_value;
        gameItem.itemWeight = p_weight;
        // Place object into your inventory
    }

    public void HoldObject(GameObject p_instance, Transform p_position)
    {
        // Instantiate the object in this position
        objectInstance = p_instance;
        objectPosition = p_position;
        gameItem.isHeld = true;

        if (gameItem.isHeld == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                gameItem.isHeld = false;

                LeaveObject(objectInstance, objectPosition);
            }
        }

    }
    
    public void LeaveObject(GameObject p_droppedInstance, Transform p_doppedPosition)
    {
        p_droppedInstance = GameObject.Instantiate(p_droppedInstance, p_doppedPosition) as GameObject;
        p_droppedInstance.transform.position = p_droppedInstance.transform.position;

        gameItem.isDropped = true;
    }

}
