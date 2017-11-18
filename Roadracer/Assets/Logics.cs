using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logics : MonoBehaviour {

    public Canvas menuCanvas;
    public GameObject mainPlayer;
    public GameObject policeCar;
    public GameObject[] enemyCars;

    private Collide col;
    private playerStats playerstats;
    private MenuManager menu;

    private void Awake()
    {
        
    }


    // Use this for initialization
    void Start () {
        //enemyCars = GameObject.FindGameObjectsWithTag("enemy_car(Clone)");
        playerstats = mainPlayer.GetComponent<playerStats>();
        menu = menuCanvas.GetComponent<MenuManager>();
        col = mainPlayer.GetComponent<Collide>();
       
        
        
        

    }
	
	// Update is called once per frame
	void Update () {
        if (col.HasCollided)
        {
            playerstats.currentHealth -= Mathf.Floor(Random.Range(3f,8f));
            menu.setHealthText = playerstats.currentHealth.ToString();
            col.HasCollided = false;
        }
	}
}
