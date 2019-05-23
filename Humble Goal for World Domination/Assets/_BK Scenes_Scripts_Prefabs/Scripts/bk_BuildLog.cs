using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bk_BuildLog : MonoBehaviour {
    public L_TowerInfo [] soliderUnits;
    private L_BuildManager buildmanager;
    public static bk_BuildLog instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        buildmanager = L_BuildManager.instance;
    }

    public void SelectRobotUnit(int indexOfUnit)
    {
        Debug.Log("Build Tower One ");
        Debug.Log(this.gameObject.name);
        buildmanager.SelectTurretToBuild(soliderUnits[indexOfUnit]);
    }
}
