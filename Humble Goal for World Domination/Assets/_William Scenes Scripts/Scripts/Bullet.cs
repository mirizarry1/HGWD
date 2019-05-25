using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnCollisionEnter(Collision collision)  // old one  
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<UnitsController>().health -= damage;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)  // new one
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<UnitsController>().health -= damage;
            Destroy(gameObject);
        }
    }
}
