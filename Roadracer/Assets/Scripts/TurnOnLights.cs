using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnLights : MonoBehaviour {

    public float minIntensity = 0.25f;
    public float maxIntensity = 0.5f;
    public Light lamplight;
    public bool lightflick = true;

    float time = 1.0f;
    float random;

    void Start()
    {
        
    }

    void Update()
    {
        time -= Time.deltaTime;
        while (lightflick == true)
        {
            random = Random.Range(0f, 10f);
            lamplight.intensity = random;
        }

        if (time == 0) {
            lamplight.intensity = 8f;
            lightflick = false;
        }
       
    }
}
