using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class L_DangerZone : MonoBehaviour {

    public List<GameObject> allunits;
    private float cooling; //unit number

    private bool hit;

    public int damage = 1;

    private float spawnTime;

    private int unitCount;
    // Use this for initialization
    void Start()
    {
        cooling = 0;
        spawnTime = 0;
        unitCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cooling += Time.deltaTime;
        spawnTime += Time.deltaTime;
        if (spawnTime > 30f)
        {
            Destroy(gameObject);
        }
        if (cooling > 1f)
        {
            hit = true;
        }
        for (int i = 0; i < allunits.Count; i++)
        {
            if (allunits[i] == null)
            {
                UnitDestroy(allunits[i]);
            }
            else
            {
                if (hit)
                {
                    StartCoroutine(CostDamage());
                }

            }
        }

    }

    IEnumerator CostDamage()
    {

        while(unitCount<allunits.Count)
        {
            for (int x = 0; x < allunits.Count; x++)
            {
                allunits[x].GetComponent<L_Units>().health -= damage;
                unitCount++;
            }
            

            yield return null;
        }
        cooling = 0;
        hit = false;
        unitCount = 0;
        yield return 0;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            allunits.Add(other.gameObject);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            allunits.Remove(other.gameObject);
        }
    }

    public void UnitDestroy(GameObject unit)
    {
        allunits.Remove(unit);
    }
}
