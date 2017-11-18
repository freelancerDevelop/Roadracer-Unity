using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class playerStats : MonoBehaviour {
    [SerializeField] private float health = 100f;
    [SerializeField] private int score = 0;

    private void Update()
    {
        if (currentHealth == 0) {
            //Gameover
            Time.timeScale = 0;
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

    public int currentScore
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

}
