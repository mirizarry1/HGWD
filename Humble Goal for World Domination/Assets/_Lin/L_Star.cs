using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Star : MonoBehaviour
{
    public int thisLevel;
    public GameObject[] stars;
    private int currentUnlock;
    private L_DataSystem DS;
	// Use this for initialization
	void Start ()
	{
	    DS = FindObjectOfType<L_DataSystem>().GetComponent<L_DataSystem>();
	    Invoke("ReadingStar",.2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ReadingStar()
    {
        currentUnlock = DS.ratingData[thisLevel];
        switch (currentUnlock)
        {
            case 1:
                stars[0].SetActive(true);
                break;
            case 2:
                stars[0].SetActive(true);
                stars[1].SetActive(true);
                break;
            case 3:
                stars[0].SetActive(true);
                stars[1].SetActive(true);
                stars[2].SetActive(true);
                break;
            default:
                Debug.Log(thisLevel + "This Level have NO score;");
                break;
        }
    }
}
