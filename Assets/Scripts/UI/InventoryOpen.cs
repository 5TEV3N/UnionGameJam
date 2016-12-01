using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InventoryOpen : MonoBehaviour
{
    public GameObject inventoryUI;
    public GameObject pauseUI;

    public bool isShowingInventoryUI;

    // Update is called once per frame
    void Update()
    {
        //uses the p button to pause and unpause the game
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (isShowingInventoryUI)
            {
                inventoryUI.SetActive(false);
                isShowingInventoryUI = false;
            }
            else if (!isShowingInventoryUI)
            {
                inventoryUI.SetActive(true);
                isShowingInventoryUI = true;
            }          
        }
    }
}

    