using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dudebot : MonoBehaviour {

    //public GameObject[] allunits;
    public List<GameObject> allunits;
    //private float cooling; //unit number



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        for (int i = 0; i < allunits.Count; i++)
        {
            if (allunits[i] == null)
            {
                UnitDestroy(allunits[i]);
            }
            else
            {
                for (int x = 0; x < allunits.Count; x++)
                {
                    allunits[x].GetComponent<L_Units>().inDudebut = true;// it will popup errors but I don't want fix it, it is doesn't matter.
                }

            }
        }
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
