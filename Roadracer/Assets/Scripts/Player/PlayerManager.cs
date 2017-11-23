using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {


    public GameObject worldGenerator;
    private float worldSpeed;


    [Header("Car Lights")]
    public Light leftheadlight;
    public Light rightheadlight;
    public Light leftrearlight;
    public Light rightrearlight;
    public Light mainlight;

    [Header("Movement")]
    public float movementSpeed;
    public float rotationSpeed;

    //Only for this script
    private Rigidbody rb;
    private int playerPos = 0;
    private bool isLightOn;

    void Start() {
        leftheadlight.enabled = false;
        rightheadlight.enabled = false;
        leftrearlight.enabled = false;
        rightrearlight.enabled = false;

        rb = GetComponent<Rigidbody>();

        

    }

	// Update is called once per frame
	void Update () {
        worldSpeed = worldGenerator.GetComponent<ObjectManager>().currentWorldMovementSpeed;
        
        //Turn on/off car lights
        TurnOnLights();
    }

    private void FixedUpdate()
    {
        //Player movement
        Movement();
    }

    private void TurnOnLights() {

        if (Input.GetKeyDown("l"))
        {
            if (isLightOn == false)
            {
                //Turn all car lights on
                leftheadlight.enabled = true;
                rightheadlight.enabled = true;
                leftrearlight.enabled = true;
                rightrearlight.enabled = true;
                mainlight.intensity = 0.2f;
                isLightOn = true;
            }
            else{
                //If they are on, turn them off
                leftheadlight.enabled = false;
                rightheadlight.enabled = false;
                leftrearlight.enabled = false;
                rightrearlight.enabled = false;
                mainlight.intensity = 1.5f;
                isLightOn = false;

            }
        }


    }

    private void Movement() {
        //Player movement
        if (Input.GetKey("s") || Input.GetKeyDown("down"))
        {
            //Move the player down
            rb.AddForce(movementSpeed * Time.deltaTime, 0, 0);                      
        }
        if (Input.GetKey("w") || Input.GetKeyDown("up"))
        {
            //Move the player up
            rb.AddForce(-movementSpeed * Time.deltaTime, 0, 0);                    
        }
        if (Input.GetKey("d") || Input.GetKeyDown("right"))
        {
            //Move the player to the right
            rb.AddForce(0, 0, movementSpeed * Time.deltaTime);            
        }  
        if (Input.GetKey("a") || Input.GetKeyDown("left"))
        {
            //Move the player to the left
            rb.AddForce(0, 0, -movementSpeed * Time.deltaTime);          
        }

        transform.rotation = Quaternion.Euler(0, rb.velocity.x * rotationSpeed, 0);
        transform.position = new Vector3(Mathf.Clamp(rb.position.x,-8,8), transform.position.y, Mathf.Clamp(rb.position.z,-20,50));
      
    }
}
    
