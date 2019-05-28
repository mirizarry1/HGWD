using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class L_RatingSystem : MonoBehaviour
{

    private int rating;
    private float fixedTime;
    private L_GameLose GL;
    public Animator oneStar;
    public Animator twoStar;
    public Animator threeStar;
    public Button nextButton;
    [Header("Should add a number! level 1 is 0, vice versa")]
    public int currentLevel;
    void Start ()
    {
        nextButton.interactable = false;
    }

    void OnEnable()
    {
        GL = FindObjectOfType<L_GameLose>().GetComponent<L_GameLose>();
        //Time.timeScale = 0;
        //fixedTime = GL.maxtime / GL.totalTime;
        fixedTime = GL.totalTime / GL.maxtime;
        CheckRating();
        if (currentLevel > PlayerPrefs.GetInt("CurrentUnlock", 0))
        {
            PlayerPrefs.SetInt("CurrentUnlock", currentLevel);
            
        }
        ChangePrefs();
        
    }

	void Update () {
		
	}

    void ChangePrefs()
    {
        switch (currentLevel)
        {
            case 0:
                if (rating > PlayerPrefs.GetInt("LV0"))
                {
                    PlayerPrefs.SetInt("LV0",rating);
                }
                break;
            case 1:
                if (rating > PlayerPrefs.GetInt("LV1"))
                {
                    PlayerPrefs.SetInt("LV1", rating);
                }
                break;
            case 2:
                if (rating > PlayerPrefs.GetInt("LV2"))
                {
                    PlayerPrefs.SetInt("LV2", rating);
                }
                break;
            case 3:
                if (rating > PlayerPrefs.GetInt("LV3"))
                {
                    PlayerPrefs.SetInt("LV3", rating);
                }
                break;
            case 4:
                if (rating > PlayerPrefs.GetInt("LV4"))
                {
                    PlayerPrefs.SetInt("LV4", rating);
                }
                break;
            case 5:
                if (rating > PlayerPrefs.GetInt("LV5"))
                {
                    PlayerPrefs.SetInt("LV5", rating);
                }
                break;
            case 6:
                if (rating > PlayerPrefs.GetInt("LV6"))
                {
                    PlayerPrefs.SetInt("LV6", rating);
                }
                break;
            case 7:
                if (rating > PlayerPrefs.GetInt("LV7"))
                {
                    PlayerPrefs.SetInt("LV7", rating);
                }
                break;
            case 8:
                if (rating > PlayerPrefs.GetInt("LV8"))
                {
                    PlayerPrefs.SetInt("LV8", rating);
                }
                break;
            case 9:
                if (rating > PlayerPrefs.GetInt("LV9"))
                {
                    PlayerPrefs.SetInt("LV9", rating);
                }
                break;
            case 10:
                if (rating > PlayerPrefs.GetInt("LV10"))
                {
                    PlayerPrefs.SetInt("LV10", rating);
                }
                break;
            case 11:
                if (rating > PlayerPrefs.GetInt("LV11"))
                {
                    PlayerPrefs.SetInt("LV11", rating);
                }
                break;

        }
    }
    void CheckRating()
    {
        if (fixedTime > 0.5)
        {
            rating = 3;
            oneStar.SetBool("OneStar", true);
            Debug.Log("Three Stars");
        }

        else if (fixedTime > 0.25)
        {
            rating = 2;
            oneStar.SetBool("OneStar", true);
            Debug.Log("Two Stars");
        }
        else
        {
            oneStar.SetBool("OneStar", true);
            rating = 1;
            Debug.Log("One Star");
        }
    }

    public void NextAnimation(int next)
    {
        switch (next)
        {
            case 1:
                Debug.Log("IN case1");
                if (rating > next)
                {
                    Debug.Log("Play two stars");
                    twoStar.SetBool("TwoStar",true);
                }
                else
                {
                    nextButton.interactable = true;
                }
                break;
            case 2:
                if (rating > next)
                {
                    threeStar.SetBool("ThreeStar", true);
                }
                else
                {
                    nextButton.interactable = true;
                }
                break;
            case 3:
                nextButton.interactable = true;
                break;
        }

       
    }

    public void NextLevelButton()
    {
        SceneManager.LoadScene("L_Test");
    }
}
