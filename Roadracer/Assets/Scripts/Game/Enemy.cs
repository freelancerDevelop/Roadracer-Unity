using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy{

    [SerializeField] private GameObject enemy;
    [SerializeField] private string name;

    public GameObject getEnemy() {
        return enemy;
    }

    public string getName() {
        return name;
    }
}
