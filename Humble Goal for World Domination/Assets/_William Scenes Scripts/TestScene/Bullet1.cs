using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnCollisionEnter(Collision collision)  // old one  
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!collision.gameObject.GetComponent<UnitsController1>().isInvulnerable)
            {
                collision.gameObject.GetComponent<UnitsController1>().health -= damage;
            }

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)  // new one
    {
        if (other.gameObject.tag == "Player")
        {
            if (!other.gameObject.GetComponent<UnitsController1>().isInvulnerable)
            {
                print("player takes damage");
                other.gameObject.GetComponent<UnitsController1>().health -= damage;
            }
            
            Destroy(gameObject);
        }
    }
}
