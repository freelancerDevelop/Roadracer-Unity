using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadlineManager : MonoBehaviour {

    private List<GameObject> roadlines;
    private float lastRoadlinePos = -40;
    private float newRoadlinePos;
    public Material roadlineMat;
    [SerializeField] private int totalNumberOfRoadlines = 300;
    public float roadlineMovementSpeed = 1f;

    [Header("Roadline Size")]
    [SerializeField] private float roadlinePartSizeX = 5;
    [SerializeField] private float roadlinePartSizeY = 0.5f;
    [SerializeField] private float roadlinePartSizeZ = 5;

    [SerializeField] private int roadlinePartsAmount = 5;

    [Header("Roadline Spawn Position")]
    [SerializeField]
    private Range roadlineSpawnPosRangeX;
    [SerializeField] private Range roadlineSpawnPosRangeY;
    [SerializeField] private Range roadlineSpawnPosRangeZ;

    [Header("Roadline Respawn Position")]
    [SerializeField] private Range roadlineRespawnPosRangeX;
    [SerializeField] private Range roadlineRespawnPosRangeY;
    [SerializeField] private Range roadlineRespawnPosRangeZ;

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
        roadlines = new List<GameObject>();
        for (int i = 0; i < totalNumberOfRoadlines; i++)
        {
            roadlines.Add(CreateNewInstance());
        }
    }

    void Update()
    {
        foreach (GameObject roadline in roadlines)
        {
            roadline.transform.Translate(0, 0, roadlineMovementSpeed * Time.deltaTime);
            if (roadline.transform.position.z < -50)
            {
                roadline.transform.position = new Vector3(0f, 0f, 235);
            }
        }
    }

    GameObject CreateNewInstance()
    {

        GameObject roadlineObject = new GameObject("Roadline");

        
        
        GameObject roadlineLeftPart = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject roadlineRightPart = GameObject.CreatePrimitive(PrimitiveType.Cube);

        roadlineLeftPart.transform.localScale = new Vector3(roadlinePartSizeX, roadlinePartSizeY, roadlinePartSizeZ);
        roadlineRightPart.transform.localScale = new Vector3(roadlinePartSizeX, roadlinePartSizeY, roadlinePartSizeZ);
        roadlineLeftPart.transform.position = new Vector3(-4, 0, 0);
        roadlineRightPart.transform.position = new Vector3(4, 0, 0);
        roadlineLeftPart.transform.parent = roadlineObject.transform;
        roadlineRightPart.transform.parent = roadlineObject.transform;
        roadlineLeftPart.GetComponent<Renderer>().material = roadlineMat;
        roadlineRightPart.GetComponent<Renderer>().material = roadlineMat;
        newRoadlinePos = lastRoadlinePos + 17;
        roadlineObject.transform.position = new Vector3(0f, 0f, newRoadlinePos);
        lastRoadlinePos = newRoadlinePos;

        return roadlineObject;
    }

    Vector3 RandomPos(Range rangeX, Range rangeY, Range rangeZ)
    {
        float randomX = rangeX.RandomInRange();
        float randomY = rangeY.RandomInRange();
        float randomZ = rangeZ.RandomInRange();
        return new Vector3(randomX, randomY, randomZ);
    }
}
