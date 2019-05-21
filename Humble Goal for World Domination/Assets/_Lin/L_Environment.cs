using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class L_Environment : MonoBehaviour
{

    public GameObject spawnObj;

    public float maxPos = 10f;

    public float minPos = -10f;

    private float posX;

    private float posY;

	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnObject", 5f,30f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnObject()
    {
        posX = Random.Range(minPos, maxPos);
        posY = Random.Range(minPos, maxPos);
        Instantiate(spawnObj, new Vector3(posX, 0.5f, posY+165), Quaternion.identity);
    }
}
