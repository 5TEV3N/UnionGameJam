using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    InputManager inputManager;

    public BasicAttribute jumpHeight = new BasicAttribute();
    public BasicAttribute playerSpeed = new BasicAttribute();
    public ObjectsInteractions gameObjectHighlight = new ObjectsInteractions();
    public ObjectsInteractions highlightThis = new ObjectsInteractions();
    public ObjectsInteractions equipThis = new ObjectsInteractions();
    
    //Stamina
    [Header("Stamina - Attributes")]
    public BasicAttribute playerStamina = new BasicAttribute();
    public bool isRunning;
    public bool canRun;
    public float staminaDecay;
   

    //Health
    [Header("Health - Attributes")]
    public BasicAttribute playerHealth = new BasicAttribute();
    public float healthDecay;
    public bool isOverTime;
    public bool isImpulse;



    [Header("Values")]
    public float mouseSensitivity = 1;                               // Mouse sensitivity
    public float jumpHeightIntensifier = 1;                          // How far i can jump
    public float playerSpeedIntensifier = 1;                         // We can controll the speed of the player here.
    public float upDownRange = 90.0f;                                // How far i can look up or down.

    public float valOfVelocity;                                      // Checks how fast the player goes
    public float maxVelocity;                                        // The max speed of how fast the player goes

    public float camRayDistance;                                     // Distance of the ray from the camera. This is to check if you can interact with an object
    public float floorRayDistance;                                   // Distance of the ray from the player. This is to check if you can Jump

    public bool isJumping;                                           // Checks if you are grounded or not

    [Header ("Containers")]
    public Rigidbody rb;                                             // Access the rigidbody to move
    public Transform heldItemLocation;
    public Camera cam;                                               // Acess the Camera of the gameobject
    public LayerMask groundMask;                                     // Layer mask to check the ground
    public LayerMask interactableMask;                               // Layer mask for the player interaction

    private float verticalRotation = 0;                              // Contains the MouseYAxis
    private float originalMaxVelocity;                               // Contains the orginal MaxVelocity  

    private RaycastHit myHit;                                        // Declaring a hit variable, registers a ray hit (gets information on hit)
    private RaycastHit floorHit;                                     // Declaring a hit variable, register a ray hit if it hits the ground 
    private Ray myRay;                                               // Declaring a ray variable, register an actual ray
    private Ray jumpingRay;                                          // Declaring a ray variable, registers an  actual ray that checks if you can jump or not
    private Vector3 startMarker;                                     // Declaring a container for the start position for the ray	

    void Awake()
    {   
        inputManager = GameObject.FindGameObjectWithTag("Player").GetComponent<InputManager>();
        originalMaxVelocity = maxVelocity;

        jumpHeight.AdjustAttribute("AdjustToNumber", 1f);
        playerSpeed.AdjustAttribute("AdjustToNumber", 1f);
        playerStamina.AdjustAttribute("AdjustToNumber", 1f);
        playerHealth.AdjustAttribute("AdjustToNumber", 1f);
    }

    void Update()
    {
        valOfVelocity = rb.velocity.magnitude;

        startMarker = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(startMarker, myRay.direction * camRayDistance, Color.magenta);

        if(Physics.Raycast(myRay, out myHit, camRayDistance, interactableMask)) // Must fix !!
        {
            GameObject interactableObject = myHit.transform.gameObject;
            highlightThis.isHighlighted = true;
            highlightThis.interactableObjRender = myHit.transform.GetComponent<Renderer>();

            if (highlightThis.isHighlighted == true)
            {
                highlightThis.HighlightOnHover(myHit.transform.gameObject, highlightThis.interactableObjRender, highlightThis.interactableObjRender.material.color, true);
            }
            if (Input.GetMouseButton(0))
            {
                highlightThis.HighlightOnHover(myHit.transform.gameObject, highlightThis.interactableObjRender, highlightThis.interactableObjRender.material.color, false);
                equipThis.HoldObject(interactableObject, heldItemLocation);
            }
        }

        Debug.DrawRay(gameObject.transform.position, Vector3.down * floorRayDistance, Color.black);
        Physics.Raycast(jumpingRay, out floorHit);
        jumpingRay = new Ray(gameObject.transform.position, Vector3.down);

        //Reduce stamina here
        if (isRunning == true) {
            ReduceStamina();
        }
        if (isRunning == false)
        {
            IncreaseStamina();
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
                    rb.AddForce(transform.right * (playerSpeed.baseAttributeCurrent * playerSpeedIntensifier));
                }   
            }

            if (xAxis < 0)
            {
                if (valOfVelocity <= maxVelocity)
                {
                    rb.AddForce(-transform.right * (playerSpeed.baseAttributeCurrent * playerSpeedIntensifier));
                }
            }
        }

        if (zAxis != 0)
        {
            if (zAxis > 0)
            {
                if (valOfVelocity <= maxVelocity)
                {
                    rb.AddForce(transform.forward * (playerSpeed.baseAttributeCurrent * playerSpeedIntensifier));
                }
            }

            if (zAxis < 0)
            {
                if (valOfVelocity <= maxVelocity)
                {
                    rb.AddForce(-transform.forward * (playerSpeed.baseAttributeCurrent * playerSpeedIntensifier));
                }
            }
        }
    }

    public void Sprint()
    {
       
        if (canRun == true && (playerStamina.baseAttributeCurrent > 0))
        { 
           
            isRunning = true;
            maxVelocity = originalMaxVelocity + 2; // main code
            
        }
    }

    public void ReduceStamina() {
        //Debug.Log(staminaDecay + "before transformation");
        float tempStaminaDecay = Mathf.Clamp01((staminaDecay * Time.deltaTime));
        //Debug.Log(staminaDecay + "after");
        playerStamina.AdjustAttribute("SubtractAmount", tempStaminaDecay);
    }

    public void IncreaseStamina()
    {
        //Debug.Log(staminaDecay + "before transformation");
        float tempStaminaDecay = Mathf.Clamp01((staminaDecay * Time.deltaTime));
        //Debug.Log(staminaDecay + "after");
        playerStamina.AdjustAttribute("AddAmount", tempStaminaDecay);
    }

    public void ReduceHealth()
    {
        Debug.Log(playerHealth.baseAttributeCurrent + "before transformation");
        float temphealthDecay = 0;
        if (isOverTime == true) {
            temphealthDecay = Mathf.Clamp01((healthDecay * Time.deltaTime));
            Debug.Log(healthDecay);
        }
        if (isImpulse == true)
        {
            temphealthDecay = healthDecay;
        }
        
        
        playerHealth.AdjustAttribute("SubtractAmount", temphealthDecay);
        Debug.Log(playerHealth.baseAttributeCurrent + "after");
    }

    public void IncreaseHealth()
    {
        //Debug.Log(staminaDecay + "before transformation");
        float tempHealthDecay = Mathf.Clamp01((healthDecay * Time.deltaTime));
        //Debug.Log(staminaDecay + "after");
        playerHealth.AdjustAttribute("AddAmount", tempHealthDecay);
    }

    public void StopSprinting()
    {
        isRunning = false;
        maxVelocity = originalMaxVelocity;
    }

    public void Jump()
    {
        if (Physics.Raycast(transform.position, Vector3.down , floorRayDistance, groundMask))
        {
            rb.AddForce(transform.up * (jumpHeight.baseAttributeCurrent * jumpHeightIntensifier), ForceMode.Impulse);

        }
    }

}
