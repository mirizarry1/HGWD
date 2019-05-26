﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_CheckPoint : MonoBehaviour
{
    private L_BuildManager buildManager;

    
	// Use this for initialization
	void Start () {
		buildManager = L_BuildManager.instance;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "Player")
        {
            if (other.gameObject.GetComponent<bk_UnitCharacteristics>().isCashIncrease == true)
            {
                buildManager.AddMoney(2f);
            }
            else
            {
                buildManager.AddMoney();
                Debug.Log("Add Money");
            }
        }
    }

    
}
