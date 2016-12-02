using UnityEngine;
using System.Collections;

public class TriggerEnter : MonoBehaviour {

   

    // Use this for initialization
    void Start () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().ReduceHealth();
            Debug.Log("Player Taking Damage at once");
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && (other.gameObject.GetComponent<PlayerController>().isImpulse == false))
            {
                other.gameObject.GetComponent<PlayerController>().isOverTime = true;
                other.gameObject.GetComponent<PlayerController>().ReduceHealth();
                Debug.Log("Player Taking Damage over time");
            }
    }
    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().isOverTime = false;
            Debug.Log("No longer over time");
        }
    }
 
}