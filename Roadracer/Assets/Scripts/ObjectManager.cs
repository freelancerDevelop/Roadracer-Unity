using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour {

    public float worldMovementSpeed;

    public Objects[] objectsToSpawn;
    public Enemy[] enemiesToSpawn;
    public int numberOfEnemies;
    private List<GameObject> allObjects;
    private List<GameObject> allEnemies;

    private float[] enemiespos = new float[]{ -7, 0, 7 };
    private float lastEnemyPos = 0;
    private float newEnemyPos;
    private int randomEnemyPos;

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

    [Header("Air Object Spawn Position")]
    [SerializeField] private Range airObjectSpawnPosRangeLeftX;
    [SerializeField] private Range airObjectSpawnPosRangeRightX;
    [SerializeField] private Range airObjectSpawnPosRangeY;
    [SerializeField] private Range airObjectSpawnPosRangeZ;

    [Header("Air Object Respawn Position")]
    [SerializeField] private Range airObjectRespawnPosRangeLeftX;
    [SerializeField] private Range airObjectRespawnPosRangeRightX;
    [SerializeField] private Range airObjectRespawnPosRangeY;
    [SerializeField] private Range airObjectRespawnPosRangeZ;

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
        allObjects = new List<GameObject>();
        allEnemies = new List<GameObject>();
        foreach (var obj in objectsToSpawn)
        {
            if (obj.OnGround)
            {
                //spawning prefabs that need to be on the ground
                for (int i = 0; i < obj.getNumberOfInstances(); i++)
                {
                    GameObject groundObject;
                    GameObject prefab = obj.getObject();
                    float randomRotate = Random.value * 360;
                    if (Random.value * 2 < 1)
                    {
                        groundObject = Instantiate(prefab, RandomPos(groundObjectSpawnPosRangeLeftX, groundObjectSpawnPosRangeY, groundObjectSpawnPosRangeZ), Quaternion.Euler(new Vector3(0, randomRotate, 0))) as GameObject;
                    }
                    else
                    {
                        groundObject = Instantiate(prefab, RandomPos(groundObjectSpawnPosRangeRightX, groundObjectSpawnPosRangeY, groundObjectSpawnPosRangeZ), Quaternion.Euler(new Vector3(0, randomRotate, 0))) as GameObject;
                    }
                    //groundObject.transform.localScale = new Vector3(Random.Range(1f, 2.5f), Random.Range(1f, 2.5f), Random.Range(1f, 2.5f));
                    allObjects.Add(groundObject);
                }
            }
            else if(!obj.OnGround){
                //spawn prefabs that need to be in the air

            }
        }

        foreach (var enemy in enemiesToSpawn)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                newEnemyPos = lastEnemyPos + Random.Range(10,20);
                randomEnemyPos = Random.Range(0, 3);
                GameObject enemyObject;
                enemyObject = Instantiate(enemy.getEnemy(), new Vector3(enemiespos[randomEnemyPos], 0.5239357f,newEnemyPos), Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
                lastEnemyPos = newEnemyPos;
                allEnemies.Add(enemyObject);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        foreach (var obj in allObjects)
        {

            obj.transform.Translate(0, 0, worldMovementSpeed * Time.deltaTime, Space.World);
            if (obj.transform.position.z < -70)
            {
                if (Random.value * 2 < 1)
                {
                    obj.transform.position = RandomPos(groundObjectRespawnPosRangeLeftX, groundObjectRespawnPosRangeY, groundObjectRespawnPosRangeZ);
                }
                else
                {
                    obj.transform.position = RandomPos(groundObjectRespawnPosRangeRightX, groundObjectRespawnPosRangeY, groundObjectRespawnPosRangeZ);
                }
            }
        }
        foreach (var enemy in allEnemies)
        {
            enemy.transform.Translate(0, 0, worldMovementSpeed * Time.deltaTime, Space.World);
            if (enemy.transform.position.z < -70)
            {
                randomEnemyPos = Random.Range(0, 3);
                enemy.transform.position = new Vector3(enemiespos[randomEnemyPos], 0.5239357f, newEnemyPos);
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
