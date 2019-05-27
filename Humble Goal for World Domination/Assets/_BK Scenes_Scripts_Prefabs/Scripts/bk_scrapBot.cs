using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bk_scrapBot : MonoBehaviour {
    private List<Collider> storage;
	// Use this for initialization
	void Start ()
    {
      
	}

    // Update is called once per frame
    //void Update ()
    //   {
    //       Collider[] nearbyUnits = UnityEngine.Physics.OverlapSphere(this.gameObject.transform.position, 4);

    //       foreach (Collider objects in nearbyUnits)
    //       {
    //           if (objects.gameObject != null && objects.tag=="Player")
    //           {
    //               print(objects.gameObject.name);
    //               objects.gameObject.GetComponent<bk_UnitCharacteristics>().isCashIncrease = true;
    //           }
    //       }
    //   }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            other.GetComponent<bk_UnitCharacteristics>().isCashIncrease = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<bk_UnitCharacteristics>().isCashIncrease = false;
        }
    }

}
