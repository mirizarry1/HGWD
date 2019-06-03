using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {
    public string[] startText;
    public string[] scoreUpdates;
    public Text dText;
    public Text score;
    public GameObject dBox;
    private Queue<string> dQueue;
    private bool dActive;
    private int loopProtector;


	// Use this for initialization
	void Start () {
        dQueue = new Queue<string>();
        dActive = true;
		foreach (string s in startText)
        {
            dQueue.Enqueue(s);
        }
        dText.text = dQueue.Dequeue();
        dQueue.Enqueue("");
        dBox.SetActive(true);
        loopProtector = 0;
	}
	
	// Update is called once per frame
	void Update () {

        scoreChecker();
        

    
        if (dActive && (Input.GetKeyDown("left shift") || Input.GetKeyDown("right shift")))
        {
         
            dText.text = dQueue.Dequeue();
            if (dQueue.Count == 0)
            {
                dBox.SetActive(false);
                dActive = false;
            }
            
            

        }
		
	}

    void scoreChecker()
    {
    
        if (score.text == "10" && loopProtector == 0)
        {
            dQueue.Clear();
            dQueue.Enqueue("10 down!");
            dText.text = "10 down!";
            dActive = true;
            dBox.SetActive(true);
            loopProtector++;
        }
        if (score.text == "20" && loopProtector == 1)
        {
            dQueue.Clear();
            dQueue.Enqueue("20 down!");
            dText.text = "20 down!";
            dActive = true;
            dBox.SetActive(true);
            loopProtector++;
        }

        if (score.text == "30" && loopProtector == 2)
        {
            dQueue.Clear();
            dQueue.Enqueue("20 left!");
            dText.text = "20 left!";
            dActive = true;
            dBox.SetActive(true);
            loopProtector++;
        }

        if (score.text == "40" && loopProtector == 3)
        {
            dQueue.Clear();
            dQueue.Enqueue("10 to go!");
            dText.text = "10 to go!";
            dActive = true;
            dBox.SetActive(true);
            loopProtector++;
        }

        if (score.text == "You win!" && loopProtector == 4)
        {
            dQueue.Clear();
            dQueue.Enqueue("Domination is mine!");
            dText.text = "Domination is mine!";
            dActive = true;
            dBox.SetActive(true);
            loopProtector++;
        }




    }

}
