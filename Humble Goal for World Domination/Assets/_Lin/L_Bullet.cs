using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Bullet : MonoBehaviour {

    [SerializeField] private float damage;
    [SerializeField] private float destroyTime;
    [SerializeField] private ParticleSystem standardHit;
    [SerializeField] private ParticleSystem theBulletItself;
    private float timer;

    private void Awake()
    {
        standardHit.Stop();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > destroyTime)
        {
            Debug.Log("Too long tome");
            Destroy(gameObject);
        }
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<L_Units>().health -= damage;
            print("I hit the player");
            Destroy(gameObject);
        }
    }
    */
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //other.gameObject.GetComponent<L_Units>().health -= damage;
            //print("I hit the player");

            ////Destroy(particleshot);
            //standardHit.Play();
            //Destroy(gameObject);
            theBulletItself.Stop();
            StartCoroutine(doDamageandParticleeffects(other));
        }
    }

    IEnumerator doDamageandParticleeffects(Collider other)
    {
        other.gameObject.GetComponent<L_Units>().health -= damage;
        print("I hit the player");

        //Destroy(particleshot);
        //theBulletItself.Stop();
        standardHit.Play();
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
        yield return null;
    }
}
