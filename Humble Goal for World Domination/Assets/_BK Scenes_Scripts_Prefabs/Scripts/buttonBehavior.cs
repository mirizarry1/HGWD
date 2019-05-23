using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonBehavior : MonoBehaviour
{
    [SerializeField] private GameObject[] untaggedunits;
    [SerializeField] private Transform spawnpointForDrag;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void spawnUnitForDrag(int untaggedUnitToSpawn)
    {
        Instantiate(untaggedunits[untaggedUnitToSpawn], spawnpointForDrag.position, spawnpointForDrag.rotation);
    }
}
