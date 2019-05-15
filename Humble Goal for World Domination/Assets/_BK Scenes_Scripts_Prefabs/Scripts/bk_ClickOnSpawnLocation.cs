using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class bk_ClickOnSpawnLocation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {    
            if(EventSystem.current.IsPointerOverGameObject())
               return;
            
            RaycastHit contactPoint;

            Ray theLaser = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(theLaser, out contactPoint, 100f))
            {
                if (contactPoint.transform != null)
                {
                    printRaycastTarget(contactPoint.transform.gameObject);
                    switch(contactPoint.transform.gameObject.name)
                    {
                        case "Spawner":
                            bk_SpawnSystem.instance.spawnPoint=contactPoint.transform.GetChild(0).transform;
                            break;
                    }
                }
            }
        }
    }

   public void printRaycastTarget(GameObject target)
    {
        print(target.name);
    }
}
