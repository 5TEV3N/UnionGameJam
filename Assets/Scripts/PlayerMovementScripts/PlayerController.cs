using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    InputManager inputManager;

    [Header("Values")]
    public float mouseSensitivity = 1;              // Mouse sensitivity
    public float playerSpeed = 1;                   // We can controll the speed of the player here.
    public float upDownRange = 90.0f;               // How far i can look up or down.
    public float valOfVelocity;                     // Checks how fast the player goes
    public float maxVelocity;                       // The max speed of how fast the player goes

    [Header ("Containers")]
    public Rigidbody rb;                            // Access the rigidbody to move
    public Camera cam;                              // Acess the Camera of the gameobject       

    private float verticalRotation = 0;             // Contains the MouseYAxis

    void Awake()
    {   
        inputManager = GameObject.FindGameObjectWithTag("Player").GetComponent<InputManager>();
    }

    void Update()
    {
        valOfVelocity = rb.velocity.magnitude;
    }

    public void Mouselook(float mouseXAxis, float mouseYAxis)
    {
        //Filter Horizontal input
        if (mouseXAxis != 0)
        {
            gameObject.transform.Rotate(new Vector3(0, mouseXAxis, 0));      
        }

        //Filter Vertical input
        if (mouseYAxis != 0)
        {
            verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;               //This section pretty much clamps your camera rotation
            verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
            cam.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);        
        } 
    }

    public void PlayerMove(float xAxis, float zAxis)
    {
        if (xAxis != 0)
        {
            if (xAxis > 0)
            {
                if (valOfVelocity <= maxVelocity)
                {
                    rb.AddForce(transform.right * playerSpeed, ForceMode.Impulse);
                }
            }

            if (xAxis < 0)
            {
                if (valOfVelocity <= maxVelocity)
                {
                    rb.AddForce(-transform.right * playerSpeed, ForceMode.Impulse);
                }
            }
        }

        if (zAxis != 0)
        {
            if (zAxis > 0)
            {
                if (valOfVelocity <= maxVelocity)
                {
                    rb.AddForce(transform.forward * playerSpeed, ForceMode.Impulse);
                }
            }

            if (zAxis < 0)
            {
                if (valOfVelocity <= maxVelocity)
                {
                    rb.AddForce(-transform.forward * playerSpeed, ForceMode.Impulse);
                }
            }
        }

    }
}
