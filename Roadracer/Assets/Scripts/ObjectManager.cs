using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour {

    public float worldMovementSpeed;
    private List<GameObject> rocks;

    [Header("Object to Spawn")]
    [SerializeField]private GameObject rockPrefab;

    [Header("Amount of Objects to Spawn")]
    [SerializeField] private int numberOfRocks;

    [Header("Ground Object Spawn Position")]
    [SerializeField] private Range groundObjectSpawnPosRangeLeftX;
    [SerializeField] private Range groundObjectSpawnPosRangeRightX;
    [SerializeField] private Range groundObjectSpawnPosRangeY;
    [SerializeField] private Range groundObjectSpawnPosRangeZ;

    [Header("Ground Object Respawn Position")]
    [SerializeField] private Range groundObjectRespawnPosRangeLeftX;
    [SerializeField] private Range groundObjectRespawnPosRangeRightX;
    [SerializeField] private Range groundObjectRespawnPosRangeY;
    [SerializeField] private Range groundObjectRespawnPosRangeZ;

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
    // Use this for initialization
    void Start () {
        rocks = new List<GameObject>();
        for (int i = 0; i < numberOfRocks; i++)
        {
            GameObject rockClone;
            if (Random.value * 2 < 1)
            {
                rockClone = Instantiate(rockPrefab, RandomPos(groundObjectRespawnPosRangeLeftX, groundObjectRespawnPosRangeY, groundObjectRespawnPosRangeZ), Quaternion.Euler(new Vector3(-90, 0, 0))) as GameObject;
            }
            else
            {
                rockClone = Instantiate(rockPrefab, RandomPos(groundObjectRespawnPosRangeRightX, groundObjectRespawnPosRangeY, groundObjectRespawnPosRangeZ), Quaternion.Euler(new Vector3(-90, 0, 0))) as GameObject;
            }
            rocks.Add(rockClone);
        }
	}
	
	// Update is called once per frame
	void Update () {
        foreach (var Rock in rocks)
        {
            Rock.transform.Translate(0, worldMovementSpeed * Time.deltaTime, 0);
            if (Rock.transform.position.z < -50)
            {
                if (Random.value * 2 < 1)
                {
                    Rock.transform.position = RandomPos(groundObjectRespawnPosRangeLeftX, groundObjectRespawnPosRangeY, groundObjectRespawnPosRangeZ);
                }
                else
                {
                    Rock.transform.position = RandomPos(groundObjectRespawnPosRangeRightX, groundObjectRespawnPosRangeY, groundObjectRespawnPosRangeZ);
                }
            }
        }
	}

    Vector3 RandomPos(Range rangeX, Range rangeY, Range rangeZ)
    {
        float randomX = rangeX.RandomInRange();
        float randomY = rangeY.RandomInRange();
        float randomZ = rangeZ.RandomInRange();
        return new Vector3(randomX, randomY, randomZ);
    }
}
