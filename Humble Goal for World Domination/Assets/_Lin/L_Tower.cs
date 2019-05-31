using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Tower : MonoBehaviour {

    [SerializeField] private Transform targetUnit;
    [SerializeField] private float timeSinceLastFire;
    [SerializeField] private float coolDowntime;
    [SerializeField] private float fireSpeed;
    [SerializeField] private Transform firePos;
    [SerializeField] private GameObject projectile;
    GameObject bullet;
    enum UnitType { IonCanon,LaserTurret};
    [SerializeField] private UnitType typeOfTower;
    [SerializeField] private bk_AudioManager audioManager;
    [SerializeField] private ParticleSystem firesparkEffect;
    private void Awake()
    {
        switch (typeOfTower)
        {
            case UnitType.IonCanon:
                firesparkEffect = this.gameObject.transform.GetChild(2).GetComponent<ParticleSystem>();
                firesparkEffect.Stop();
                break;

            case UnitType.LaserTurret:
                firesparkEffect = this.gameObject.transform.GetChild(0).GetComponent<ParticleSystem>();
                firesparkEffect.Stop();
                break;

        }
    }
        void Start ()
    {
        firePos = GetComponent<Transform>();
        audioManager = GameObject.FindObjectOfType<bk_AudioManager>();
	}
	
	// Update is called once per frame
	void Update () {
        
	    if (targetUnit != null && timeSinceLastFire > coolDowntime)
	    {
            GameObject bullet = Instantiate(projectile, firePos.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = (targetUnit.position - bullet.transform.position) * fireSpeed;
            switch (typeOfTower)
            {
                case UnitType.IonCanon:
                    audioManager.audioSourceComponents[2].Play();
                    break;

                case UnitType.LaserTurret:
                    audioManager.audioSourceComponents[4].Play();
                    break;

            }
            bullet = Instantiate(projectile, firePos.position, Quaternion.identity);
            firesparkEffect.Play();
            timeSinceLastFire = 0;
	    }
	    if (bullet)
	    {
	        Vector3 direction = targetUnit.position - bullet.transform.position;
	        bullet.transform.position += direction.normalized * Time.deltaTime * fireSpeed;
	    }
	    timeSinceLastFire += Time.deltaTime;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            targetUnit = other.transform;
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == targetUnit)
        {
            targetUnit = null;
        }
    }
}
