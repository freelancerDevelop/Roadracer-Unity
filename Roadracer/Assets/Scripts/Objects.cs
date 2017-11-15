using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Objects{


    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private string objectName;
    public bool OnGround;
    [SerializeField] private int NumberOfInstances;

    public GameObject getObject() {
        return objectToSpawn;
    }

    public string getObjectName() {
        return objectName;
    }

    public int getNumberOfInstances() {
        return NumberOfInstances;
    }
}
