using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIEngine : MonoBehaviour {

	// public NarrativeUI enterRoomUI;
	public string textToShow;
	public Text uiTextBoxToUse;
	public bool isNarrativeUIShowing;
	public bool isMenuShowing;

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
	public void DisplayMenu(){
		
	}
	public void HideMenu(){
		
	}
	public void SelectMenuItem(){
		
	}
	public void ShowCursor(){

	}
    public void HideCursor() {
    }
	public void LockCursor(){
	}
}
