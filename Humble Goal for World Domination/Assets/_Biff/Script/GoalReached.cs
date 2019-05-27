using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalReached : MonoBehaviour {
    public Text score;
    public Text dText;
    public GameObject dBox;
    public GameObject levelSelect;
    public DialogManager dMan;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (score.text == "50")
        {
            dText.text = "Victory!";
            dBox.SetActive(true);
            levelSelect.SetActive(true);
           
        } 
		
	}
}
