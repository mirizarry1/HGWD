using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] WayPoints1 WP;
    [SerializeField] SpawnUnit SU;



    private void OnMouseDown()
    {
        SU.spawningPoint = WP;
    }
}
