using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceChase : MonoBehaviour {

    public GameObject policecar;
    public GameObject player;
    public float RotationSpeed;

    private Quaternion _lookRotation;
    private Vector3 _direction;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        startPoliceChase();
	}

    void startPoliceChase() {
        float step = RotationSpeed * Time.deltaTime;
        Vector3 playerposition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 14);

        policecar.transform.position = Vector3.Lerp(policecar.transform.position,playerposition,Time.deltaTime/1.5f);

        ////Rotate police car towards the player
        //_direction = (player.transform.position - policecar.transform.position);

        ////create the rotation we need to be in to look at the target
        //_lookRotation = Quaternion.LookRotation(_direction);
        
        ////rotate us over time according to speed until we are in the required rotation
        //policecar.transform.rotation = Quaternion.Slerp(policecar.transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);

        Vector3 targetDir = player.transform.position - policecar.transform.position;
        Vector3 newDir = Vector3.RotateTowards(policecar.transform.right, targetDir, step, 0.0F);
        Debug.DrawRay(policecar.transform.position, targetDir, Color.red);
        policecar.transform.rotation = Quaternion.LookRotation(targetDir);
    }

}
