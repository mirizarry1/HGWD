using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        max,
    }
    public UpgradeState upgradeState;
    [SerializeField] private int firstUpgradeMoney;
    [SerializeField] private int secondUpgradeMoney;
    [SerializeField] private int thirdUpgradeMoney;
    [SerializeField] private int fourthUpgradeMoney;
    [SerializeField] private float HpUpgrade;
    [SerializeField] private float speedUpgrade;
    [SerializeField] private Text upgradeLevel;


    // This is for initialization
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
        switch (upgradeState)
        {
            case UpgradeState.first:

                if (buildManager.totalMoney < firstUpgradeMoney)
                {
                    return;
                }

                buildManager.totalMoney -= firstUpgradeMoney;

                L_Units.powerUpHP += HpUpgrade;
                L_Units.powerUpSpeed += speedUpgrade;

                foreach (var unit in Units)
                {
                    unit.health += HpUpgrade;
                    unit.speed += speedUpgrade;
                }

                upgradeLevel.text = "Level: 1";
                upgradeState = UpgradeState.second;

                break;
            case UpgradeState.second:

                if (buildManager.totalMoney < secondUpgradeMoney)
                {
                    return;
                }

                buildManager.totalMoney -= secondUpgradeMoney;

                L_Units.powerUpHP += HpUpgrade;
                L_Units.powerUpSpeed += speedUpgrade;

                foreach (var unit in Units)
                {
                    unit.health += HpUpgrade;
                    unit.speed += speedUpgrade;
                }

                upgradeLevel.text = "Level: 2";
                upgradeState = UpgradeState.third;

                break;
            case UpgradeState.third:

                if (buildManager.totalMoney < thirdUpgradeMoney)
                {
                    return;
                }

                buildManager.totalMoney -= thirdUpgradeMoney;

                L_Units.powerUpHP += HpUpgrade;
                L_Units.powerUpSpeed += speedUpgrade;

                foreach (var unit in Units)
                {
                    unit.health += HpUpgrade;
                    unit.speed += speedUpgrade;
                }

                upgradeLevel.text = "Level: 3";
                upgradeState = UpgradeState.fourth;

                break;
            case UpgradeState.fourth:

                if (buildManager.totalMoney < fourthUpgradeMoney)
                {
                    return;
                }

                buildManager.totalMoney -= fourthUpgradeMoney;

                L_Units.powerUpHP += HpUpgrade;
                L_Units.powerUpSpeed += speedUpgrade;

                foreach (var unit in Units)
                {
                    unit.health += HpUpgrade;
                    unit.speed += speedUpgrade;
                }

                upgradeLevel.text = "Level: max";
                upgradeState = UpgradeState.max;

                break;
        }
        
    }
}
