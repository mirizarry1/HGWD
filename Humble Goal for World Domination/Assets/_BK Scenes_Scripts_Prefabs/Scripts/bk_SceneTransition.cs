using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bk_SceneTransition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeScene(int sceneIndex)
    {
        switch(sceneIndex)
        {
            case 0:
                SceneManager.LoadScene(0);
                break;

            case 1:
                SceneManager.LoadScene(1);
                break;
            case 2:
                SceneManager.LoadScene(2);
                break;
        }
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
