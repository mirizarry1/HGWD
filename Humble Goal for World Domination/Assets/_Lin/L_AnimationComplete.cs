using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_AnimationComplete : MonoBehaviour
{


    public int animationNumber;

    private L_RatingSystem RS;
        // Use this for initialization
	void Start ()
	{
	    RS = FindObjectOfType<L_RatingSystem>().GetComponent<L_RatingSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FinishedAnimation()
    {
        RS.NextAnimation(animationNumber);

    }
}
