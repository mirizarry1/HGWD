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

            unit.transform.localScale = new Vector3(50, 50, 50);
        }

        StartCoroutine("Vulnerable");
    }

    IEnumerator Vulnerable()
    {
        yield return new WaitForSeconds(invulnerableTime);

        foreach (var unit in Units)
        {
            unit.isInvulnerable = false;

            unit.transform.localScale = new Vector3(20, 20, 20);

        }
    }
}
