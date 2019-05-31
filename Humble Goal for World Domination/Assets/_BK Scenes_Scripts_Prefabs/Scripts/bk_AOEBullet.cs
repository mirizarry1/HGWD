using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bk_AOEBullet : MonoBehaviour
{
    [SerializeField] float explosionRadius; // the radius that the AOE damage should affect
    [SerializeField] float explosionForce; // force put behind the explosion that only affects the enemies
    [SerializeField] LayerMask effectedLayers; // a variable to set what layers are affected by the explosion should be a layer called enemy
    [SerializeField] float damage;
    [SerializeField] float lifeExpectancy;
    [SerializeField] private ParticleSystem standardHit;
    [SerializeField] private ParticleSystem theBulletItself;
    private float timer;
    // Use this for initialization
    //void OnCollisionEnter(Collision col)  // upon the fireball colliding with an object the particle effect goes off and the particle effect and fireball are destroyed
    //{
    //    Debug.Log("1111111111111");



    //    AddExplosiveForce(col.contacts[0].point); // the method that performs the AOE affect

    //    print(col.gameObject.name);
    //    Destroy(gameObject);

    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //other.gameObject.GetComponent<L_Units>().health -= damage;
            //AddExplosiveForce(other.transform.position);
            //print("AOE hit the player");
            //Destroy(gameObject);
            theBulletItself.Stop();
            StartCoroutine(doDamageandParticleeffects(other));
        }
    }
    void AddExplosiveForce(Vector3 centerOfExplosion)
    {
        Debug.Log("222222222");
        Collider[] thingsHit = UnityEngine.Physics.OverlapSphere(centerOfExplosion, explosionRadius, effectedLayers); // methods that detects a radius of collision points to perform AOE effects
        foreach (Collider hit in thingsHit) // for each collider found in detection radius it finds the rigidbody of that object and applies a force to it
        {
            print("Object being hit: " + hit.gameObject.name);
            print("This is the gameobject that it colided with: " + hit.gameObject.name);
            if (hit.GetComponent<Rigidbody>() != null)
            {
                hit.gameObject.GetComponent<L_Units>().health-=damage;
                //hit.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, centerOfExplosion, explosionRadius, 0, ForceMode.Impulse); // ads a force to each collider
            }
        }
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>=lifeExpectancy)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator doDamageandParticleeffects(Collider other)
    {
        other.gameObject.GetComponent<L_Units>().health -= damage;
        print("I hit the player");
        AddExplosiveForce(other.transform.position);
        //Destroy(particleshot);
        //theBulletItself.Stop();
        standardHit.Play();
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
        yield return null;
    }
}
