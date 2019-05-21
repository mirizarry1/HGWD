using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Friendship : MonoBehaviour
{
    //public GameObject[] allunits;
    public List<GameObject> allunits;
    private float cooling; //unit number

    private bool heal;

    public int addHealth;
    private int unitCount;
    // Use this for initialization
    void Start ()
	{
	    cooling = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    cooling += Time.deltaTime;
	    if (cooling > 2f)
	    {
	        heal = true;
	    }
	    for (int i = 0; i < allunits.Count; i++)
	    {
	        if (allunits[i]==null)
	        {
                UnitDestroy(allunits[i]);
            }
	        else
	        {
	            if (heal)
	            {
	                StartCoroutine(HealUP());
	            }
	            
	        }
	    }
	}

    IEnumerator HealUP()
    {
        while (unitCount < allunits.Count)
        {
            for (int x = 0; x < allunits.Count; x++)
            {
                allunits[x].GetComponent<L_Units>().health += addHealth;
                unitCount++;
            }


            yield return null;
        }
        cooling = 0;
        heal = false;
        unitCount = 0;
        yield return 0;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            allunits.Add(other.gameObject);
            L_Units unit = other.gameObject.GetComponent<L_Units>();

        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            allunits.Remove(other.gameObject);
            L_Units unit = other.gameObject.GetComponent<L_Units>();
        }
    }

    public void UnitDestroy(GameObject unit)
    {
        allunits.Remove(unit);
    }
   
}
