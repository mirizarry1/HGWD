using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bk_Armortron : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<L_Units>().health+= (other.GetComponent<L_Units>().maxHealth*.2f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<L_Units>();
        }
    }
}
