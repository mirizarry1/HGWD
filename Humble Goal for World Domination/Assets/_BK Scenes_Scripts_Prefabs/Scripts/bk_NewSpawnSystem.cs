using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bk_NewSpawnSystem : MonoBehaviour
{
    [SerializeField]private L_TowerInfo unitToSpawn;
    [SerializeField]private L_BuildPoint spawningPlace;
    public Button[] listofButtonImages;
    private GameObject indicatorToTurnOff;
    // Use this for initialization
    void Start () {
		
	}
	public void revertallButtonPanels()
    {
        foreach(Button b in listofButtonImages)
        {
            b.GetComponent<Image>().color = Color.white;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            unitToSpawn = bk_BuildLog.instance.soliderUnits[0];
            L_BuildManager.instance.SelectTurretToBuild(unitToSpawn);
            revertallButtonPanels();
            listofButtonImages[0].GetComponent<Image>().color = Color.green;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            unitToSpawn = bk_BuildLog.instance.soliderUnits[1];
            L_BuildManager.instance.SelectTurretToBuild(unitToSpawn);
            revertallButtonPanels();
            listofButtonImages[1].GetComponent<Image>().color = Color.green;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            unitToSpawn = bk_BuildLog.instance.soliderUnits[2];
            L_BuildManager.instance.SelectTurretToBuild(unitToSpawn);
            revertallButtonPanels();
            listofButtonImages[2].GetComponent<Image>().color = Color.green;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            unitToSpawn = bk_BuildLog.instance.soliderUnits[3];
            L_BuildManager.instance.SelectTurretToBuild(unitToSpawn);
            revertallButtonPanels();
            listofButtonImages[3].GetComponent<Image>().color = Color.green;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            unitToSpawn = bk_BuildLog.instance.soliderUnits[4];
            L_BuildManager.instance.SelectTurretToBuild(unitToSpawn);
            revertallButtonPanels();
            listofButtonImages[4].GetComponent<Image>().color = Color.green;
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            unitToSpawn = bk_BuildLog.instance.soliderUnits[5];
            L_BuildManager.instance.SelectTurretToBuild(unitToSpawn);
            revertallButtonPanels();
            listofButtonImages[5].GetComponent<Image>().color = Color.green;
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            unitToSpawn = bk_BuildLog.instance.soliderUnits[6];
            L_BuildManager.instance.SelectTurretToBuild(unitToSpawn);
            revertallButtonPanels();
            listofButtonImages[6].GetComponent<Image>().color = Color.green;
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                
                if (hit.transform != null && hit.transform.gameObject.name=="Spawner")
                {
                    if(indicatorToTurnOff==null)
                    {
                        spawningPlace = hit.transform.gameObject.GetComponent<L_BuildPoint>();
                        indicatorToTurnOff = hit.transform.gameObject.transform.GetChild(0).gameObject;
                        indicatorToTurnOff.SetActive(true);
                    }
                    else
                    {
                        indicatorToTurnOff.SetActive(false);
                        spawningPlace = hit.transform.gameObject.GetComponent<L_BuildPoint>();
                        indicatorToTurnOff = hit.transform.gameObject.transform.GetChild(0).gameObject;
                        indicatorToTurnOff.SetActive(true);
                    }
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.Space) && unitToSpawn.prefab!= null && spawningPlace!=null)
        {
            spawningPlace.BuildTurret(L_BuildManager.instance.GetTurretToBuild());
        }

    }
}
