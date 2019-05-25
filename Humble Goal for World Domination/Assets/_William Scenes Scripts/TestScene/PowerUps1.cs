using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps1 : MonoBehaviour
{
    public List<UnitsController1> Units;

    [SerializeField] private float speedUpMultiplier;
    [SerializeField] private float speedUpTime;
    [SerializeField] private float invulnerableTime;



    public void MovementSpeedUp()
    {
        foreach (var unit in Units)
        {
            unit.speed *= speedUpMultiplier;
        }

        StartCoroutine("NormalSpeed");
    }

    IEnumerator NormalSpeed()
    {
        yield return new WaitForSeconds(speedUpTime);

        foreach (var unit in Units)
        {
            unit.speed /= speedUpMultiplier;
        }
    }

    public void Invulnerable()
    {
        print("invulnerable");
        foreach (var unit in Units)
        {
            unit.isInvulnerable = true;
        }

        StartCoroutine("Vulnerable");
    }

    IEnumerator Vulnerable()
    {
        yield return new WaitForSeconds(invulnerableTime);

        foreach (var unit in Units)
        {
            unit.isInvulnerable = false;
        }
    }
}
