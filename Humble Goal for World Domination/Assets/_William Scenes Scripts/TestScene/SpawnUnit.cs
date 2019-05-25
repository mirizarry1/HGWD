using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnit : MonoBehaviour {

    public GameObject unitPrefab;
    public WayPoints1 spawningPoint;


    public void SpawnUnits()
    {
        if (spawningPoint != null)
        {
            GameObject unit = Instantiate(unitPrefab, spawningPoint.transform.GetChild(0).position, Quaternion.identity);
            GameObject.FindObjectOfType<PowerUps1>().Units.Add(unit.GetComponent<UnitsController1>());
        }
        
    }
}
