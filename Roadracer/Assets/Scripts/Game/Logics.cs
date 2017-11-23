using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logics : MonoBehaviour {

    //Initialize the object i want to use for logics
    public Canvas menuCanvas;
    public GameObject mainPlayer;
    public GameObject policeCar;
    public GameObject[] enemyCars;
    public GameObject worldGenerator;

    //Used to store the reference script
    private Collide col;
    private playerStats playerstats;
    private MenuManager menu;
    private ObjectManager objman;

  


    // Use this for initialization
    void Start () {
        //Get the scripts from the objects
        objman = worldGenerator.GetComponent<ObjectManager>();
        playerstats = mainPlayer.GetComponent<playerStats>();
        menu = menuCanvas.GetComponent<MenuManager>();
        col = mainPlayer.GetComponent<Collide>();
    }
	
	// Update is called once per frame
	void Update () {

        //Check if the player has collided with an enemy.
        //If so, then the player takes damage.
        if (col.HasCollided)
        {
            playerstats.currentHealth -= Mathf.Floor(Random.Range(3f,8f));
            menu.setHealthText = playerstats.currentHealth.ToString();
            col.HasCollided = false;
        }

        //Increase world speed over time
        objman.currentWorldMovementSpeed -= 0.010f;

	}

    public float increaseWorldSpeed()
    {
        float worldSpeed = 0;
        return worldSpeed;
    }
}
