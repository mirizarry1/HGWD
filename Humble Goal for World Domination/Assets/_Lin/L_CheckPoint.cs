using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_CheckPoint : MonoBehaviour
{
    private L_BuildManager buildManager;
    private PowerUps PU;
    
	// Use this for initialization
	void Start () {
		buildManager = L_BuildManager.instance;
        PU = GameObject.FindObjectOfType<PowerUps>();
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
            else if (other.GetComponent<Chadbot>())
            {
                PU.speedTime += 1;
                PU.invTime += 1;
                Debug.Log("Enter this !!!!!!!!!!!!1");
            }
            else
            {
                buildManager.AddMoney();
                Debug.Log("Add Money");
            }
        }

        

    }

    
}
