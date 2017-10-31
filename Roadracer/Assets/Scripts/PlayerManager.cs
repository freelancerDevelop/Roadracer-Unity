using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    
    private int playerPos = 0;
	// Update is called once per frame
	void Update () {
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
        if (playerPos == -1) {
            transform.position = new Vector3(-7f, 1, 0);
        }
        else if (playerPos == 0)
        {
            transform.position = new Vector3(0, 1, 0);

        }
        else if (playerPos == 1)
        {
            transform.position = new Vector3(7f, 1, 0);

        }

    }
}
