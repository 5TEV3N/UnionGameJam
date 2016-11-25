using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Memories : MonoBehaviour
{
    // Add this script to the Memories Manager in the scene

    public List<GameObject> memoriesThatDerivesFrom = new List<GameObject>();

    public void GetMemories()
    {
        // if the player interacts with a story related object that presents a memory, redirect to this function.
    }

    public void PlayMemories()
    {
        // instatiate the memory from the list
    }
}
