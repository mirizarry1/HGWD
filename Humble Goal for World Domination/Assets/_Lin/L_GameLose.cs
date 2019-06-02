using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class L_GameLose : MonoBehaviour
{
    public int maxtime;
    public float totalTime;
	// Use this for initialization
    public Text timeText;
    private float minit;
    private float second;
    private L_BuildManager buildManager;

    public GameObject lostScreen;

    public GameObject uiScreen;

    public GameObject buildScreen;

    public GameObject timeout;

    public GameObject nounit;
    //[SerializeField]private List<GameObject> allUnit;
    [SerializeField] private GameObject[] units = new GameObject[0];
	void Start ()
	{
	    totalTime = maxtime;
        buildManager = L_BuildManager.instance;
        
	}
	
	// Update is called once per frame
	void Update ()
	{
	    units = GameObject.FindGameObjectsWithTag("Player");
        if (totalTime > 0)
	    {
	        totalTime -= Time.deltaTime;
	        minit = totalTime / 60;
	        second = totalTime % 60;
            if (second < 10)
            {
                Debug.Log("We're in the if!");
                timeText.text = ((int)minit).ToString() + ":" + "0" + ((int)second).ToString();
            }
            else
            {
                timeText.text = ((int)minit).ToString() + ":" + ((int)second).ToString();
            }
        }
	    else
	    {
	        Debug.Log("Time Out!!");
            lostScreen.SetActive(true);
            buildScreen.SetActive(false);
	        uiScreen.SetActive(false);
	        timeout.SetActive(true);
	    }

	    if (buildManager.totalMoney <= 10)
	    {
	        if (units.Length == 0)
	        {
                Debug.Log("Game Lose");
	            lostScreen.SetActive(true);
	            buildScreen.SetActive(false);
	            uiScreen.SetActive(false);
	            nounit.SetActive(true);
	        }
	    }
	    

    }

    public void TryAgain()
    {
        //SceneManager.LoadScene("");
    }
}
