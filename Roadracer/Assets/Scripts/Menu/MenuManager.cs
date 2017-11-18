using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour {

    public Camera mainCamera;
    public GameObject player;
    
    public TextMeshProUGUI healthText;
    private Vector3 mainCameraPlayPosition = new Vector3(40, 40, 30);
    private Vector3 mainCameraMenuPosition = new Vector3(63, 40, 30);
    public bool moveCameraToPlay = false;
    public bool moveCameraToMenu = false;

    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Move the camera to the play area
        if (moveCameraToPlay)
        {
            cameraToMainPos();
        }
        if (moveCameraToMenu) {
            cameraToMenuPos();

        }

        //Move the camera back to the menu area
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            moveCameraToPlay = false;
            moveCameraToMenu = true;

        }
        healthText.text = player.GetComponent<playerStats>().currentHealth.ToString();
       

    }

    public void QuitGame()
    {
        Debug.Log("Quit Application");
        Application.Quit();
    }

    public void MuteAudio() {

        //Mute all audio
    }

    public void cameraToMainPos() {
        
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, mainCameraPlayPosition, Time.deltaTime * 2);
        mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, Quaternion.Euler(45, -90, 0), Time.deltaTime * 2);
        //if (mainCamera.transform.position == mainCameraPlayPosition)
        //{
        //    moveCamera = false;
        //}
        
    }

    public void cameraToMenuPos() {
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position,mainCameraMenuPosition,Time.deltaTime*2);
        mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, Quaternion.Euler(70, -90, 0), Time.deltaTime * 2);


    }

    public void onMoveCamera() {
        moveCameraToPlay = true;
        moveCameraToMenu = false;
    }

    public string setHealthText {
        set {
            healthText.text = value;
        }
    }
    
}
