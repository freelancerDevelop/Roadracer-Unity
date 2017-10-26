using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour {

    private List<GameObject> trees;
    [SerializeField] private int totalNumberOfTrees = 300;
    public float treeMovementSpeed = 1f;
    [Header("Tree Materials")]
    public Material treeRootMat;
    public Material treeLeafMat;

    [Header("Tree Size")]
    [SerializeField] private float treeLeafSizeX = 5f;
    [SerializeField] private float treeLeafSizeY = 0.5f;
    [SerializeField] private float treeLeafSizeZ = 5f;
    [SerializeField] private int treeLeafsAmount = 5;

    [Header("Tree Spawn Position")]
    [SerializeField] private Range treeSpawnPosRangeX;
    [SerializeField] private Range treeSpawnPosRangeY;
    [SerializeField] private Range treeSpawnPosRangeZ;

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
        
        trees = new List<GameObject>();
        for (int i = 0; i < totalNumberOfTrees; i++)
        {
            trees.Add(CreateNewInstance(treeLeafsAmount));
        }
    }

    void Update()
    {
        foreach (GameObject tree in trees)
        {
            tree.transform.Translate(0, 0, treeMovementSpeed * Time.deltaTime);
        }
    }
    
    GameObject CreateNewInstance(int numberOfTreeParts)
    {
        
        GameObject treeObject = new GameObject("Tree");      
        GameObject treeRoot = GameObject.CreatePrimitive(PrimitiveType.Cube);
        treeRoot.transform.localScale = new Vector3(1, 8, 1);
        treeRoot.GetComponent<Renderer>().material = treeRootMat;
        treeRoot.transform.parent = treeObject.transform;

        for (int i = 0; i < numberOfTreeParts; i++)
        {
            GameObject treeLeaf = GameObject.CreatePrimitive(PrimitiveType.Cube);
            treeLeaf.transform.localScale = new Vector3(Random.Range(1f,treeLeafSizeX), Random.Range(1f,treeLeafSizeY), Random.Range(1f, treeLeafSizeZ));
            treeLeaf.transform.position = new Vector3(Random.Range(-1f,1f), Random.Range(3f, 5.5f), Random.Range(-1f,1f));
            treeLeaf.transform.parent = treeObject.transform;
            treeLeaf.GetComponent<Renderer>().material = treeLeafMat;

        }
        treeObject.transform.position = RandomPos(treeSpawnPosRangeX, treeSpawnPosRangeY, treeSpawnPosRangeZ);
        return treeObject;
    }

    Vector3 RandomPos(Range rangeX, Range rangeY, Range rangeZ)
    {
        float randomX = rangeX.RandomInRange();
        float randomY = rangeY.RandomInRange();
        float randomZ = rangeZ.RandomInRange();
        return new Vector3(randomX, randomY, randomZ);
    }
}
