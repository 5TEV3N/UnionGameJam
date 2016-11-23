using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class EnterRoomText : MonoBehaviour
{
   // public NarrativeUI enterRoomUI;
    public string enterBedRoomText;
    public Text uiTextBoxToUse;
    bool enterRoom;



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enterRoom = true;

            
            DisplayNarrativeText(enterBedRoomText, uiTextBoxToUse);
            //enterRoomUI.DisplayNarrativeText(enterBedRoomText, uiTextBoxToUse);
        }
    }



    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enterRoom = false;
            DisableNarrativeText(uiTextBoxToUse);

        }
    }
    //Show and hide narrative. Set narrative in Display with textToShow
    public void DisableNarrativeText(Text narrativeBox)
    {
        narrativeBox.gameObject.SetActive(false);
    }
    public void DisplayNarrativeText(string textToShow, Text narrativeBox)
    {
        narrativeBox.gameObject.SetActive(true);
        narrativeBox.text = textToShow;
    }
}