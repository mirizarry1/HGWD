using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L_DataSystem : MonoBehaviour
{
    [SerializeField]private int currentUnlock;
    public List<int> ratingData;
    public Button[] allButtons;
    //public GameObject[] allButtons;
	void Start ()
	{
        LoadAllData();
	    currentUnlock = PlayerPrefs.GetInt("CurrentUnlock", 0);
        CheckUnlock();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadAllData()
    {
        ratingData.Add(PlayerPrefs.GetInt("LV0", 0));
        ratingData.Add(PlayerPrefs.GetInt("LV1", 0));
        ratingData.Add(PlayerPrefs.GetInt("LV2", 0));
        ratingData.Add(PlayerPrefs.GetInt("LV3", 0));
        ratingData.Add(PlayerPrefs.GetInt("LV4", 0));
        ratingData.Add(PlayerPrefs.GetInt("LV5", 0));
        ratingData.Add(PlayerPrefs.GetInt("LV6", 0));
        ratingData.Add(PlayerPrefs.GetInt("LV7", 0));
        ratingData.Add(PlayerPrefs.GetInt("LV8", 0));
        ratingData.Add(PlayerPrefs.GetInt("LV9", 0));
        ratingData.Add(PlayerPrefs.GetInt("LV10", 0));
        ratingData.Add(PlayerPrefs.GetInt("LV11", 0));

    }
    void CheckUnlock()
    {
        for (int i = 0; i <= currentUnlock; i++)
        {
            allButtons[i].interactable = true;
        }
    }
}
