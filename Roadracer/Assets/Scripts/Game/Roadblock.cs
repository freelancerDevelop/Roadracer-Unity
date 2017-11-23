using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roadblock {

    private GameObject carInRoadBlock;
    private GameObject carLeft;
    private GameObject carMid;
    private GameObject carRight;
    private GameObject completeRoadblock;
  
    private List<GameObject> cars = new List<GameObject>();

    //gapPosition 1 =left 2=mid 3=right
    private int gapPosition;
    private int leftPosx = -7;
    private int midPosx = 0;
    private int rightPosx = 7;

    public Roadblock(GameObject car) {
        this.carInRoadBlock = car;
        this.gapPosition = Mathf.CeilToInt(Random.value*3);
        spawnCars();
        setGap(gapPosition);
    }

    private void spawnCars()
    {
        completeRoadblock = new GameObject("Roadblock");

        carLeft = MonoBehaviour.Instantiate(carInRoadBlock, new Vector3(leftPosx, 0.52f, 0), rotateforRoadblock());
        carMid = MonoBehaviour.Instantiate(carInRoadBlock, new Vector3(midPosx, 0.52f, 0), rotateforRoadblock());
        carRight = MonoBehaviour.Instantiate(carInRoadBlock, new Vector3(rightPosx, 0.52f, 0), rotateforRoadblock());

        carLeft.transform.parent = completeRoadblock.transform;
        carMid.transform.parent = completeRoadblock.transform;
        carRight.transform.parent = completeRoadblock.transform;

        completeRoadblock.transform.position = new Vector3(0, 0, 100);

        cars.Add(carLeft);
        cars.Add(carMid);
        cars.Add(carRight);

        

    }

    public int getGap() {
        return gapPosition;
    }

    public List<GameObject> getCarsInRoadblock() {
        return cars;

    }

    public GameObject getRoadblock() {
        return completeRoadblock;
    }

    public void respawnRoadblock() {
        gapPosition = Mathf.CeilToInt(Random.value * 3);
        setGap(gapPosition);   
        changeRoadblockPosition();
        repositionCars();

    }

    private Quaternion rotateforRoadblock() {
        return Quaternion.Euler(0, 90, 0);
    }

    private void changeRoadblockPosition() {
        completeRoadblock.transform.position = new Vector3(0, 0, 100);
    }

    private void repositionCars() {
        carLeft.transform.position = new Vector3(leftPosx, 0.52f, completeRoadblock.transform.position.z);
        carMid.transform.position = new Vector3(midPosx, 0.52f, completeRoadblock.transform.position.z);
        carRight.transform.position = new Vector3(rightPosx, 0.52f, completeRoadblock.transform.position.z);
     
        foreach (var car in cars)
        {
            car.transform.rotation = rotateforRoadblock();
        }
    }

    private void setGap(int gap) {
        foreach (var car in cars)
        {
            car.SetActive(true);
        }
        if (gap == 1)
        {             
            carLeft.SetActive(false);
        }
        if (gap == 2)
        {          
            carMid.SetActive(false);
        }
        if (gap == 3)
        {          
            carRight.SetActive(false);
        }

    }

}
