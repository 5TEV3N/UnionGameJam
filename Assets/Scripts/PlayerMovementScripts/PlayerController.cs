using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    InputManager inputManager;

    [Header("Values")]
    public float mouseSensitivity = 1;              // Mouse sensitivity
    public float jumpHeight = 1;                    // How far i can jump
    public float playerSpeed = 1;                   // We can controll the speed of the player here.
    public float upDownRange = 90.0f;               // How far i can look up or down.

    public float valOfVelocity;                     // Checks how fast the player goes
    public float maxVelocity;                       // The max speed of how fast the player goes

    public float camRayDistance;                    // Distance of the ray from the camera. This is to check if you can interact with an object
    public float floorRayDistance;                  // Distance of the ray from the player. This is to check if you can Jump

    public bool isJumping;                          // Checks if you are grounded or not

    [Header ("Containers")]
    public Rigidbody rb;                            // Access the rigidbody to move
    public Camera cam;                              // Acess the Camera of the gameobject
    public LayerMask groundMask;                    // Layer mask to check the ground

    private float verticalRotation = 0;             // Contains the MouseYAxis
    private float originalMaxVelocity;              // Contains the orginal MaxVelocity

    private RaycastHit myHit;                       // Declaring a hit variable, registers a ray hit (gets information on hit)
    private RaycastHit floorHit;                    // Declaring a hit variable, register a ray hit if it hits the ground 
    private Ray myRay;                              // Declaring a ray variable, register an actual ray
    private Ray jumpingRay;                         // Declaring a ray variable, registers an  actual ray that checks if you can jump or not
    private Vector3 startMarker;                    // Declaring a container for the start position for the ray	

    void Awake()
    {   
        inputManager = GameObject.FindGameObjectWithTag("Player").GetComponent<InputManager>();
        originalMaxVelocity = maxVelocity;
    }

    void Update()
    {
        valOfVelocity = rb.velocity.magnitude;

        startMarker = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        myRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(startMarker, myRay.direction * camRayDistance, Color.magenta);
        Debug.DrawRay(gameObject.transform.position, Vector3.down * floorRayDistance, Color.black);

        jumpingRay = new Ray(gameObject.transform.position, Vector3.down );
        Physics.Raycast(jumpingRay, out floorHit);
    }
    
    public GameObject CastRay() // Disclamer, I did this 2nd semester
    {    
        //Actually Cast the ray on Command --> output collider to myhit ("out" keyword). myhit=  has information from myray and puts it into myHit
        Physics.Raycast(myRay, out myHit, camRayDistance);   // Casts a ray
        //Print collider hit, filter null errors
        if (myHit.collider != null)
        {
            //print (myHit.collider.gameObject.GetComponent<C_Tiles>().id); <-- Example of printing something from an object
            return myHit.collider.gameObject; // gets the actual game object within the scene, scripts and all
        }
        else
        {
            return null; //returns nothing
        }

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
                    rb.AddForce(transform.right * playerSpeed);
                }   
            }

            if (xAxis < 0)
            {
                if (valOfVelocity <= maxVelocity)
                {
                    rb.AddForce(-transform.right * playerSpeed);
                }
            }
        }

        if (zAxis != 0)
        {
            if (zAxis > 0)
            {
                if (valOfVelocity <= maxVelocity)
                {
                    rb.AddForce(transform.forward * playerSpeed);
                }
            }

            if (zAxis < 0)
            {
                if (valOfVelocity <= maxVelocity)
                {
                    rb.AddForce(-transform.forward * playerSpeed);
                }
            }
        }
    }

    public void Sprint()
    {
        maxVelocity = originalMaxVelocity + 2;
    }

    public void StopSprinting()
    {
        maxVelocity = originalMaxVelocity;
    }

    public void Jump()
    {
        if (Physics.Raycast(transform.position, Vector3.down , floorRayDistance, groundMask))
        {
            rb.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
        }
    }

}
