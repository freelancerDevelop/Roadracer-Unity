using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    private List<GameObject> clouds;
    public Material cloudMat;
    [SerializeField] private int totalNumberOfClouds = 300;
    public float cloudMovementSpeed = 1f;

    [Header("Cloud Size")]
    [SerializeField] private int cloudPartSizeX = 5;
    [SerializeField] private float cloudPartSizeY = 0.5f;
    [SerializeField] private int cloudPartSizeZ = 5;

    [SerializeField] private int cloudPartsAmount = 5;

    [Header("Cloud Spawn Position")]
    [SerializeField] private Range cloudSpawnPosRangeX;
    [SerializeField] private Range cloudSpawnPosRangeY;
    [SerializeField] private Range cloudSpawnPosRangeZ;

    [System.Serializable]
    private class Range
    {
        public float Minimum;
        public float Maximum;

        public Range(float Minimum, float Maximum)
        {
            this.Minimum = Minimum;
            this.Maximum = Maximum;
        }
        public float RandomInRange()
        {
            if (Minimum == Maximum || Minimum > Maximum)
                return Minimum;

            float range = Maximum - Minimum;
            return Minimum + (range * Random.value);
        }
    }

    void Start()
    {
        clouds = new List<GameObject>();
        for (int i = 0; i < totalNumberOfClouds; i++)
        {
            clouds.Add(CreateNewInstance(cloudPartsAmount));
        }
    }

    void Update()
    {
        foreach (GameObject cloud in clouds)
        {
            cloud.transform.Translate(0, 0, cloudMovementSpeed * Time.deltaTime);
        }   
    }

    GameObject CreateNewInstance(int numberOfCloudParts) {
        
        GameObject cloudObject = new GameObject("Cloud");
        
        for (int i = 0; i < numberOfCloudParts; i++)
        {
            GameObject cloudPart = GameObject.CreatePrimitive(PrimitiveType.Cube);

            cloudPart.transform.localScale = new Vector3(cloudPartSizeX, cloudPartSizeY, cloudPartSizeZ);
            cloudPart.transform.position = new Vector3(Random.value * 5, Random.Range(20f,21f), Random.value * 5);
            cloudPart.transform.parent = cloudObject.transform;
            cloudPart.GetComponent<Renderer>().material = cloudMat;

        }
        cloudObject.transform.position = RandomPos(cloudSpawnPosRangeX, cloudSpawnPosRangeY, cloudSpawnPosRangeZ);

        return cloudObject;      
    }

    Vector3 RandomPos(Range rangeX, Range rangeY, Range rangeZ)
    {
        float randomX = rangeX.RandomInRange();
        float randomY = rangeY.RandomInRange();
        float randomZ = rangeZ.RandomInRange();
        return new Vector3(randomX, randomY, randomZ);
    }
}

   



