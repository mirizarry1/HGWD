using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class L_Units : MonoBehaviour {

    //private Transform target;
    //private NavMeshAgent unit;
    enum UnitType {Foddertron,Scrapbot,Armoroton,FriendshipUnit,RX76,Chadbot,Voltron};
    [SerializeField]private UnitType typeOfUnit;
    private float unitSpeed;
    public float health;
    public float maxHealth;
    public bool isDead;
    //Way point 
    [SerializeField] private Transform targetWayPoint;
    [SerializeField] private int wayPointIndex = 0;
    public WayPoints WP;
    public float speed;
    public int waypoint;

    //---------------PowerUps-----------------------
    public bool isInvulnerable;
    public PowerUps powerUps;
    public bool alreadySpeedUp;

    //******************************************
    public static float powerUpHP;
    public static float powerUpSpeed;
    //******************************************

    public  Slider healthSlider;

    public bool inDudebut = false;
    //private L_Friendship[] friendUnit;
    [SerializeField] private ParticleSystem IDiagnoseYouWithDeath;
    [SerializeField] private ParticleSystem standardHit;
    [SerializeField] private ParticleSystem AOEExplosion;
    public bool dying = false;
    private void Awake()
    {
        IDiagnoseYouWithDeath.Stop();
        standardHit.Stop();
        AOEExplosion.Stop();
    }
    void Start ()
    {
        Physics.IgnoreLayerCollision(11, 11);

        //******************************
        health += powerUpHP;
        speed += powerUpHP;
        //******************************

        switch (typeOfUnit)
        {
            case UnitType.Scrapbot:
                print("This is a Scrapbot");
                break;
        }

        WP = L_BuildManager.instance.wayP[waypoint];
        maxHealth = health;
        targetWayPoint = WP.wayPoints[wayPointIndex];
        //healthSlider = GetComponent<Slider>();

        powerUps = GameObject.FindObjectOfType<PowerUps>();

    }

    IEnumerator doDamageandParticleeffects()
    {
        dying = true;
        IDiagnoseYouWithDeath.Play();
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        yield return null;
    }
    public void standardPlay()
    {
        StartCoroutine(doStandardBlastParticleeffects());
    }
    IEnumerator doStandardBlastParticleeffects()
    {
        //Destroy(particleshot);
        //theBulletItself.Stop();
        standardHit.Play();
        yield return new WaitForSeconds(.5f);
        standardHit.Stop();
        yield return null;
    }
    public void aoePlay()
    {
        StartCoroutine(doAOEParticlesHit());
    }
    IEnumerator doAOEParticlesHit()
    {
        AOEExplosion.Play();
        yield return new WaitForSeconds(.5f);
        AOEExplosion.Stop();
        yield return null;
    }
    void Update ()
	{
        //unit.SetDestination(target.position);
        //FaceTarget();
	    

        if ( health<= 0)
        {
            isDead = true;
            print("Unit died");
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            powerUps.Units.Remove(gameObject.GetComponent<L_Units>());
            print("unit remove from list");
            //Destroy(gameObject);
            if (dying == false)
            {
                StartCoroutine(doDamageandParticleeffects());
            }
	    }
	    Vector3 direction = targetWayPoint.position - transform.position;
        if (health > 0)
        {
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
	    if (Vector3.Distance(transform.position, targetWayPoint.position) < 0.2f)
	    {
	        GetNextWayPoint();
	    }

	    //healthSlider.value = health / maxHealth;
	}
    private void GetNextWayPoint()
    {
        

        wayPointIndex++;
        targetWayPoint = WP.wayPoints[wayPointIndex];
    }
    /*
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    */
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(other.gameObject.GetComponent<Collider>(), this.gameObject.GetComponent<Collider>());
        }
        if (other.gameObject.tag == "Target")
        {
            L_BuildManager.instance.AddScore(1);
            powerUps.Units.Remove(gameObject.GetComponent<L_Units>());
            Destroy(this.gameObject);
        }
    }
}
