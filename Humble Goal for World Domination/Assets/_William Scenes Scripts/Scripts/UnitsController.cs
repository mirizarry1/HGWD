using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitsController : MonoBehaviour
{
    [SerializeField] private Transform targetWayPoint;
    [SerializeField] private Transform targetTower;
    [SerializeField] private int wayPointIndex = 0;
    public float speed;
    public float health;
    public float damage;

    public Text score;
    public static int enemyHP;

    public WayPoints WP;

	// Use this for initialization
	void Start ()
    {
        enemyHP = 50;
        targetWayPoint = WP.wayPoints[wayPointIndex];
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (health <= 0)
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
        if (wayPointIndex >= WP.wayPoints.Length -1)
        {
            //targetTower.GetComponent<Tower>().health -= damage;
            Destroy(gameObject);
            enemyHP--;
            score.text = enemyHP.ToString();
            return;
        }

        wayPointIndex++;
        targetWayPoint = WP.wayPoints[wayPointIndex];
    }

   
   
}
