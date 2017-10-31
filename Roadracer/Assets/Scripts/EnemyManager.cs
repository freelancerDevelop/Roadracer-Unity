using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    private List<GameObject> enemies;
    private float lastEnemyPos = -40;
    private float newEnemyPos;
    public int enemyMovementSpeed;
    public int numberOfEnemies;
    public Material enemyMat;

    [Header("Roadline Spawn Position")]
    [SerializeField] private Range roadlineSpawnPosRangeX;
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
    // Use this for initialization
    void Start () {
        enemies = new List<GameObject>();
        for (int i = 0; i < numberOfEnemies; i++)
        {
            enemies.Add(CreateNewEnemy());
        }
	}
	
	// Update is called once per frame
	void Update () {
            foreach (GameObject enemy in enemies)
            {
                enemy.transform.Translate(0, 0, enemyMovementSpeed * Time.deltaTime);
                if (enemy.transform.position.z < -50) {
                    float xpos = Mathf.Ceil(Random.value * 3);
                    if (xpos == 3)
                    {
                    //Most Right Position
                        enemy.transform.position = new Vector3(7, 1, 100);
                    }
                    else if (xpos == 2)
                    {
                    //Middle position
                        enemy.transform.position = new Vector3(0, 1, 100);
                    }
                    else if (xpos == 1)
                    {
                    //Most left position
                        enemy.transform.position = new Vector3(-7, 1, 100);
                    }
                }
            }
        }

    GameObject CreateNewEnemy() {

        GameObject enemyObject = new GameObject("Enemy");
        GameObject enemy = GameObject.CreatePrimitive(PrimitiveType.Cube);
        enemy.transform.localScale = new Vector3(1, 1, 1);
        enemy.GetComponent<Renderer>().material = enemyMat;
        enemy.transform.parent = enemyObject.transform;
        newEnemyPos = lastEnemyPos + 17;
        float xpos = Mathf.Ceil(Random.value * 3);
        if (xpos == 3){
            //Most Right Position
            enemyObject.transform.position = new Vector3(7, 1, newEnemyPos);
        }
        else if(xpos == 2){
            //Middle position
            enemyObject.transform.position = new Vector3(0, 1, newEnemyPos);
        }
        else if(xpos == 1){
            //Most left position
            enemyObject.transform.position = new Vector3(-7, 1, newEnemyPos);
        }
        lastEnemyPos = newEnemyPos;
        return enemyObject;
    }
}
