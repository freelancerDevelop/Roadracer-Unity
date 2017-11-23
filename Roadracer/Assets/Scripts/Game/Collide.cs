using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour {

    private bool hasCollided = false;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "policecarRoadblock(Clone)") {      
            hasCollided = true;
        }
        
    }

    public bool HasCollided {
        get {
            return hasCollided;
        }
        set {
            hasCollided = value;
        }
       
    }    
}
