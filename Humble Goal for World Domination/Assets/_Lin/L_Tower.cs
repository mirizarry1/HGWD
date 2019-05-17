﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Tower : MonoBehaviour {

    [SerializeField] private Transform targetUnit;
    [SerializeField] private float timeSinceLastFire;
    [SerializeField] private float coolDowntime;
    [SerializeField] private float fireSpeed;
    [SerializeField] private Transform firePos;
    [SerializeField] private GameObject projectile;
    GameObject bullet;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	    if (targetUnit != null && timeSinceLastFire > coolDowntime)
	    {
	        //GameObject bullet = Instantiate(projectile, firePos.position, Quaternion.identity);
	        //bullet.GetComponent<Rigidbody>().velocity = (targetUnit.position - bullet.transform.position) * fireSpeed;

	        bullet = Instantiate(projectile, firePos.position, Quaternion.identity);
	        timeSinceLastFire = 0;
	    }
	    if (bullet)
	    {
	        Vector3 direction = targetUnit.position - bullet.transform.position;
	        bullet.transform.position += direction.normalized * Time.deltaTime * fireSpeed;
	    }
	    timeSinceLastFire += Time.deltaTime;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            targetUnit = other.transform;
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other == targetUnit)
        {
            targetUnit = null;
        }
    }
}
