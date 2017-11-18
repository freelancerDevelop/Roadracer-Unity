using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchLight : MonoBehaviour {

    private Vector3 newPosition;
    public Light helilight;
    public GameObject player;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SearchForPlayer();
	}

    private void SearchForPlayer() {
        Vector3 playerposition = new Vector3(player.transform.position.x, 30, player.transform.position.z-8);

        helilight.transform.position = Vector3.Lerp(helilight.transform.position, playerposition, Time.deltaTime);


    }
}
