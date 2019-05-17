using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class L_Units : MonoBehaviour {

    //private Transform target;
    //private NavMeshAgent unit;
    private float unitSpeed;
    public float health;
    //Way point 
    [SerializeField] private Transform targetWayPoint;
    [SerializeField] private int wayPointIndex = 0;
    public WayPoints WP;
    public float speed;
    public int waypoint;
    void Start ()
    {
        WP = L_BuildManager.instance.wayP[waypoint];
        //target = L_BuildManager.instance.targeTransform;
        //unit = GetComponent<NavMeshAgent>();
        //unitSpeed = unit.speed;
        targetWayPoint = WP.wayPoints[wayPointIndex];
    }
	

	void Update ()
	{
        //unit.SetDestination(target.position);
        //FaceTarget();
	    

        if ( health<= 0)
	    {
	        print("Unit died");
	        Destroy(gameObject);
	    }
	    Vector3 direction = targetWayPoint.position - transform.position;
	    transform.Translate(direction.normalized * speed * Time.deltaTime);

	    if (Vector3.Distance(transform.position, targetWayPoint.position) < 0.2f)
	    {
	        GetNextWayPoint();
	    }
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
