using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class L_Build : MonoBehaviour {
    public L_TowerInfo towerone;
    public L_TowerInfo unitTwo;
    private L_BuildManager buildmanager;
    void Start()
    {
        buildmanager = L_BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Build Tower One ");
        buildmanager.SelectTurretToBuild(towerone);
    }
    public void SelectFriendUnit()
    {
        Debug.Log("Build unit 2 ");
        buildmanager.SelectTurretToBuild(unitTwo);
    }
}

