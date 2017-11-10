﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    [Header("Car Lights")]
    public Light leftheadlight;
    public Light rightheadlight;
    public Light leftrearlight;
    public Light rightrearlight;

    private int playerPos = 0;
    private bool isLightOn;

    void Start() {
        leftheadlight.enabled = false;
        rightheadlight.enabled = false;
        leftrearlight.enabled = false;
        rightrearlight.enabled = false;

    }

	// Update is called once per frame
	void Update () {
        //Player movement
        Movement();

        //Turn on/off car lights
        TurnOnLights();
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
                isLightOn = true;
            }
            else{
                //If they are on, turn them off
                leftheadlight.enabled = false;
                rightheadlight.enabled = false;
                leftrearlight.enabled = false;
                rightrearlight.enabled = false;
                isLightOn = false;

            }
        }


    }

    private void Movement() {
        //Player movement
        if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
        {
            playerPos += 1;
        }
        if (Input.GetKeyDown("a") || Input.GetKeyDown("left"))
        {
            playerPos -= 1;
        }
        if (playerPos == 2) { playerPos = 1; }
        if (playerPos == -2) { playerPos = -1; }
        if (playerPos == -1)
        {
            transform.position = new Vector3(-7f, 0.5f, 0);
        }
        else if (playerPos == 0)
        {
            transform.position = new Vector3(0, 0.5f, 0);

        }
        else if (playerPos == 1)
        {
            transform.position = new Vector3(7f, 0.5f, 0);

        }

    }
}
