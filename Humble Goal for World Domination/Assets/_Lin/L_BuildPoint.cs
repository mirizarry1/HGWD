using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class L_BuildPoint : MonoBehaviour {
    public Color enterColor;
    public Color exitColor;
    public GameObject turret;

    private L_BuildManager buildManager;
    private Renderer rend;
    private Color startColor;
    public Vector3 fixedPosition = new Vector3(0.5f,.25f,0.5f);

    public int waypointNum;

    //-----------------PowerUps-----------------------------
    public PowerUps powerUps;

    // Use this for initialization
    void Start ()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = L_BuildManager.instance;

        powerUps = GameObject.FindObjectOfType<PowerUps>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnMouseDown()
    {
        print("this gameobject that was clicked on is called: " + this.gameObject.name);
        buildManager.SelectTurretToBuild(this.gameObject.GetComponent<bk_setUnitForSpawner>().spawnpointUnitType);
        if (!buildManager.CanBuild)
            return;
        if (this.gameObject.GetComponent<bk_setUnitForSpawner>().spawnpointUnitType.prefab!=null)
        {
            //buildManager.SelectTurretToBuild(this.gameObject.GetComponent<bk_setUnitForSpawner>().spawnpointUnitType);
            BuildTurret(buildManager.GetTurretToBuild());
        }
    }
    
    public Vector3 GetBuildPosition()
    {
        return transform.position + fixedPosition;
    }
    void BuildTurret(L_TowerInfo blueprint)
    {
        if (buildManager.totalMoney < blueprint.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        buildManager.totalMoney -= blueprint.cost;

        //GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        turret.GetComponent<L_Units>().waypoint = waypointNum;
        //turretBlueprint = blueprint;

        //Debug.Log("Turret build!");


        powerUps.Units.Add(turret.GetComponent<L_Units>());



    }
    
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = enterColor;

        }
        else
        {
            rend.material.color = exitColor;
        }

    }

    void OnMouseExit()
    {
        rend.material.color = startColor;

    }
    
}
