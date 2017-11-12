using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceChase : MonoBehaviour {

    public GameObject policecar;
    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        startPoliceChase();
	}

    void startPoliceChase() {
        Vector3 playerposition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 12);

        policecar.transform.position = Vector3.Lerp(policecar.transform.position,playerposition,Time.deltaTime/2);
    }

}
