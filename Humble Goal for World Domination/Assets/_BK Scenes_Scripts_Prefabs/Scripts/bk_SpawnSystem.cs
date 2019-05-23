using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bk_SpawnSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] robotUnitsAvailable;
    public static bk_SpawnSystem instance;
    public Transform spawnPoint;
    [SerializeField] private WayPoints wp;

    private L_BuildManager buildmanager;
    // Use this for initialization
    void Start () {
        instance = this;
        buildmanager = L_BuildManager.instance;
	}
	
	// Update is called once per frame
	void Update () {
        print("Blah");
	}

    public void spawnUnit(int unitType)
    {
        if (spawnPoint != null&& buildmanager.totalMoney>4)
        {
            GameObject soliderUnit = Instantiate(robotUnitsAvailable[unitType], spawnPoint.position, Quaternion.identity) as GameObject;
            soliderUnit.GetComponent<UnitsController>().WP = wp;
            buildmanager.totalMoney -=5;
        }
    }
}
