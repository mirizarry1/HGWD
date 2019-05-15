using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class L_Build : MonoBehaviour {
    public L_TowerInfo towerone;
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
}

