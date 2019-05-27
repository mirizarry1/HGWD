using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonBehavior : MonoBehaviour
{
    [SerializeField] private GameObject[] untaggedunits;
    [SerializeField] private Transform spawnpointForDrag;
    public bool isSpawnReady;
    public static buttonBehavior instance;
	// Use this for initialization
	void Start ()
    {
        instance = this;
        isSpawnReady = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void spawnUnitForDrag(int untaggedUnitToSpawn)
    {
        if (isSpawnReady == true)
        {
            Instantiate(untaggedunits[untaggedUnitToSpawn], spawnpointForDrag.position, spawnpointForDrag.rotation);
            isSpawnReady = false;
        }
    }
}
