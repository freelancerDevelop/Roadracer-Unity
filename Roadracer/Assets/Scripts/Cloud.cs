using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    
    [SerializeField] private int poolSize = 300;
    [SerializeField] private int cubeSizeX = 5;
    [SerializeField] private float cubeSizeY = 0.5f;
    [SerializeField] private int cubeSizeZ = 5;
    [SerializeField] private int cloudPositionRangeX = 5;
    [SerializeField] private int cloudPositionY = 13;
    [SerializeField] private int cloudPositionRangeZ = 5;
    [SerializeField] private int nCloudparts = 5;
    public float speed = 1f;
    public GameObject cloudObject;

    private List<Cloud> pool;
    // Use this for initialization
    void Start()
    {
        pool = new List<Cloud>();
        for (int i = 0; i < poolSize; i++)
        {
            pool.Add(CreateNewInstance(nCloudparts));
            
        }
        
        //totalcloud.transform.localScale = new Vector3(3, 0.5f, 5);
        //totalcloud.transform.position = new Vector3(Random.value * 7, (Random.value * 2) + 13, Random.value * 7);

    }

    void Update()
    {
        foreach (Cloud c in pool)
        {
            c.gameObject.transform.Translate(0, 0, speed * Time.deltaTime);
        }   
    }

    Cloud CreateNewInstance(int nCubes) {
        
            cloudObject = new GameObject("Cloud");
            //Transform cloudPool = null;
        
            for (int i = 0; i < nCubes; i++)
            {
                GameObject cloudPart = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cloudPart.transform.localScale = new Vector3(cubeSizeX, cubeSizeY, cubeSizeZ);
                cloudPart.transform.position = new Vector3(Random.value * 7, 13, Random.value * 7);
                cloudPart.transform.parent = cloudObject.transform;
                cloudPart.SetActive(true);
            
            }
            cloudObject.transform.position = new Vector3((Random.value * cloudPositionRangeX) -150, (Random.value) + cloudPositionY, Random.value * cloudPositionRangeZ);
            Cloud cloud = cloudObject.GetComponent<Cloud>();
            
            
            
            return cloud;      
    }
}

   



