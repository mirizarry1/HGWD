using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bk_PauseMenu : MonoBehaviour {

    // Use this for initialization
    [SerializeField] private GameObject pausemenu;

    public void pauseGame()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void resumeGame()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
