using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L_BuildManager : MonoBehaviour
{

    public int totalMoney;

    public int addCircuits;
    //

    private L_TowerInfo towerInfo;
    private L_BuildPoint selectPoint;

    public static L_BuildManager instance;
    public bool CanBuild { get { return towerInfo != null; } }
    public bool HasMoney { get { return totalMoney >= towerInfo.cost; } }
    public Text moneyText;

  
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }
    void Start () {
		
	}
 

    void Update ()
	{
	    moneyText.text = totalMoney.ToString();
        
	}

    public void AddMoney()
    {
        totalMoney += addCircuits;
    }
    public void SelectPoint(L_BuildPoint point)
    {
        if (selectPoint == point)
        {
            DeselectPlace();
            return;
        }

        selectPoint = point;
        towerInfo = null;

    }
   
    public void DeselectPlace()
    {
        selectPoint = null;

    }

    public void SelectTurretToBuild(L_TowerInfo turret)
    {
        towerInfo = turret;
        DeselectPlace();

    }

    public L_TowerInfo GetTurretToBuild()
    {
        return towerInfo;
    }

    public void ButtonClick()
    {
        Debug.Log("This Button Clicked");
    }
}
