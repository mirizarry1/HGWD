using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    public Text[] boardText; // drage & drop by hand 


    // Use this for initialization
    void Start ()
    {
        for (int i = 0; i < boardText.Length; i++)
        {
            boardText[i].text = "Level " + (i + 1) + " : " + PlayerPrefs.GetString("LeaderBoard" + i);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
