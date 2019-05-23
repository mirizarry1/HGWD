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
    private float maxHealth;
    public bool isDead;
    //Way point 
    [SerializeField] private Transform targetWayPoint;
    [SerializeField] private int wayPointIndex = 0;
    public WayPoints WP;
    public float speed;
    public int waypoint;

    public  Slider healthSlider;
    //private L_Friendship[] friendUnit;
   
    void Start ()
    {
        switch(typeOfUnit)
        {
            case UnitType.Scrapbot:
                print("This is a Scrapbot");
                break;
        }

        WP = L_BuildManager.instance.wayP[waypoint];
        maxHealth = health;
        targetWayPoint = WP.wayPoints[wayPointIndex];
        //healthSlider = GetComponent<Slider>();
    }
	

	void Update ()
	{
        //unit.SetDestination(target.position);
        //FaceTarget();
	    

        if ( health<= 0)
        {
            isDead = true;
            print("Unit died");
	        Destroy(gameObject);
	    }
	    Vector3 direction = targetWayPoint.position - transform.position;
	    transform.Translate(direction.normalized * speed * Time.deltaTime);

	    if (Vector3.Distance(transform.position, targetWayPoint.position) < 0.2f)
	    {
	        GetNextWayPoint();
	    }

	    healthSlider.value = health / maxHealth;
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
        if (other.gameObject.tag == "Target")
        {
            L_BuildManager.instance.AddScore(1);
            Debug.Log("ADD One Point");
            Destroy(this.gameObject);
        }
    }
}
