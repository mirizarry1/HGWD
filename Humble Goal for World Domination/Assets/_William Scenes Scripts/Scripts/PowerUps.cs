using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    //public List<UnitsController> Units;
    public List<L_Units> Units;

    [SerializeField] private float speedUpMultiplier;
    [SerializeField] private float speedUpTime;
    [SerializeField] private float invulnerableTime;
    [SerializeField] private float invulnerableMultiplier;

    //------------Upgrade--------------------------------
    private L_BuildManager buildManager;
    public float speedTime;
    public float invTime;
    public enum UpgradeState
    {
        first = 0,
        second,
        third,
        fourth,
    }
    public UpgradeState upgradeState;

    private void Start()
    {
        buildManager = L_BuildManager.instance;

    }

    public void MovementSpeedUp()
    {
        foreach (var unit in Units)
        {
            if (!unit.alreadySpeedUp)
            {
                if (unit.inDudebut == true)
                {
                    unit.speed *= 2*speedUpMultiplier;
                    unit.alreadySpeedUp = true;
                }
                else
                {
                    unit.speed *= speedUpMultiplier;
                    unit.alreadySpeedUp = true;
                }
                
            }
        }

        StartCoroutine("NormalSpeed");
    }

    IEnumerator NormalSpeed()
    {
        speedTime = 0f;
        //yield return new WaitForSeconds(speedUpTime);
        while (speedTime<speedUpTime)
        {
            speedTime += Time.deltaTime;
            yield return null;
        }

        foreach (var unit in Units)
        {
            if (unit.alreadySpeedUp)
            {
                unit.speed /= speedUpMultiplier;
                unit.alreadySpeedUp = false;
            }
        }

    }

    public void Invulnerable()
    {
        print("invulnerable");
        foreach (var unit in Units)
        {
            unit.isInvulnerable = true;

            unit.transform.localScale = new Vector3(20 * invulnerableMultiplier, 20 * invulnerableMultiplier, 20 * invulnerableMultiplier);
        }

        StartCoroutine("Vulnerable");
    }

    IEnumerator Vulnerable()
    {
        //yield return new WaitForSeconds(invulnerableTime);
        speedTime = 0f;
        //yield return new WaitForSeconds(speedUpTime);
        while (invTime < invulnerableTime)
        {
            invTime += Time.deltaTime;
            yield return null;
        }
        foreach (var unit in Units)
        {
            unit.isInvulnerable = false;

            unit.transform.localScale = new Vector3(20, 20, 20);
        }
    }

    public void Upgrade()
    {
        print("Upgrade");
        switch (upgradeState)
        {
            case UpgradeState.first:

                if (buildManager.totalMoney < 5)
                {
                    Debug.Log("Not enough money to build that!");
                    return;
                }

                buildManager.totalMoney -= 5;

                foreach (var unit in Units)
                {
                    unit.health += 2;
                    unit.speed += 0.5f;
                }

                upgradeState = UpgradeState.second;

                break;
            case UpgradeState.second:

                if (buildManager.totalMoney < 25)
                {
                    Debug.Log("Not enough money to build that!");
                    return;
                }

                buildManager.totalMoney -= 25;
                foreach (var unit in Units)
                {
                    unit.health += 2;
                    unit.speed += 0.5f;
                }

                upgradeState = UpgradeState.third;

                break;
            case UpgradeState.third:

                if (buildManager.totalMoney < 125)
                {
                    Debug.Log("Not enough money to build that!");
                    return;
                }

                buildManager.totalMoney -= 125;
                foreach (var unit in Units)
                {
                    unit.health += 2;
                    unit.speed += 0.5f;
                }

                upgradeState = UpgradeState.fourth;

                break;
            case UpgradeState.fourth:

                if (buildManager.totalMoney < 625)
                {
                    Debug.Log("Not enough money to build that!");
                    return;
                }

                buildManager.totalMoney -= 625;
                foreach (var unit in Units)
                {
                    unit.health += 2;
                    unit.speed += 0.5f;
                }

                break;
            default:
                break;
        }
        
    }
}
