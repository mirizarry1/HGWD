using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMouseDragTest : MonoBehaviour {
    public GameObject[] soliders;
    [SerializeField] private int unitToSpawn;
    float distance = 10;
    private Vector3 initial;
    [SerializeField] private bk_BuildLog buildSwitch;
    private void Start()
    {
        buildSwitch = bk_BuildLog.instance;    
    }
    public void setUnitToSpawn(int index)
    {
        unitToSpawn = index;
    }
    private void OnMouseEnter()
    {
        initial = this.gameObject.transform.position;
    }
    private void OnMouseDrag()
    {
        print(initial.y);
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y-initial.y);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = objPosition;

        RaycastHit contactPoint;

        Ray theLaser = Camera.main.ScreenPointToRay(Input.mousePosition);
        print(gameObject.name);
        if (Physics.Raycast(gameObject.transform.position,-gameObject.transform.up ,out contactPoint, 150f))
        {
            if (contactPoint.transform != null)
            {
                printRaycastTarget(contactPoint.transform.gameObject);
                switch (contactPoint.transform.gameObject.name)
                {
                    case "Spawner":
                        bk_BuildLog.instance.SelectRobotUnit(unitToSpawn);
                        break;
                }
            }
        }
    }
    private void OnMouseUp()
    {
        RaycastHit contactPoint;

        Ray theLaser = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(gameObject.transform.position, -gameObject.transform.up, out contactPoint, 100f))
        {
            if (contactPoint.transform != null)
            {
                printRaycastTarget(contactPoint.transform.gameObject);
                switch (contactPoint.transform.gameObject.name)
                {
                    case "Spawner":
                        bk_BuildLog.instance.SelectRobotUnit(unitToSpawn);
                        contactPoint.transform.gameObject.GetComponent<bk_setUnitForSpawner>().spawnpointUnitType = bk_BuildLog.instance.soliderUnits[unitToSpawn];
                        break;
                }
            }
        }
        buttonBehavior.instance.isSpawnReady = true;
        Destroy(this.gameObject);
    }
    public void printRaycastTarget(GameObject target)
    {
        print(target.name);
    }

}
