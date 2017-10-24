using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] GameObject cloud = null;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            CreateNewInstance(5);
            
        }
        
        //totalcloud.transform.localScale = new Vector3(3, 0.5f, 5);
        //totalcloud.transform.position = new Vector3(Random.value * 7, (Random.value * 2) + 13, Random.value * 7);

    }


    Cloud CreateNewInstance(int nCubes) {
        
            GameObject cloudObject = new GameObject("CloudInstance");
            for (int i = 0; i < nCubes; i++)
            {
                cloudObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cloudObject.transform.localScale = new Vector3(3, 0.5f, 5);
                cloudObject.transform.position = new Vector3(Random.value * 7, (Random.value) + 13, Random.value * 7);
            
            }
            cloudObject.transform.position = new Vector3(Random.value * 27, (Random.value) + 13, Random.value * 27);
            Cloud cloud = cloudObject.GetComponent<Cloud>();
            
            
            return cloud;   

        
        
    }
}

   



