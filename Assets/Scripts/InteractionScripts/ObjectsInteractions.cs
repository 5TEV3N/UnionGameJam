using UnityEngine;
using System.Collections;

public class ObjectsInteractions
{
    public GameObject objectInstance;
    public Transform objectPosition;
    public bool isHighlighted;

    private Color orginalColor;
    private Renderer interactableObjRender;
    private GameObject interactableObj;

    private BasicItem gameItem = new BasicItem();

    public void HighlightOnHover(GameObject p_thisGameObject, Renderer p_interactableObjRender, Color p_objOriginalColor)
    {
        orginalColor = p_objOriginalColor;
        interactableObjRender = p_interactableObjRender;
        interactableObj = p_thisGameObject;

        if (isHighlighted == true)

        {
            interactableObjRender = interactableObj.GetComponent<Renderer>();
            orginalColor = interactableObjRender.material.color;
            interactableObjRender.material.color = orginalColor + new Color32(200, 200, 200, 1);

        }
        else
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

                LeaveObject(p_instance);
            }
        }

    }
    
    public void LeaveObject(GameObject p_droppedInstance)
    {
        //if holding an object is happening, you may drop that object
        gameItem.isDropped = true;
    }
}
