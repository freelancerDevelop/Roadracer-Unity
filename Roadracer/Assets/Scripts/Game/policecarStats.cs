using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class policecarStats : MonoBehaviour {

    [SerializeField] private float health = 100f;

    private void Update()
    {
        if (currentHealth == 0)
        {
            //Move car back to start position
            
        }
    }


    public float currentHealth
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }
}
