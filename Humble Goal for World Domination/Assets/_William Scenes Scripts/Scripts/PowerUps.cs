using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField] private List<UnitsController> Units;

    [SerializeField] private float speedUpMultiplier;


    private void Start()
    {
        
    }
    public void MovementSpeedUp()
    {
        foreach (var unit in Units)
        {
            unit.speed *= speedUpMultiplier;
        }
    }

}
