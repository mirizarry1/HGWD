using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSomeTrigger : MonoBehaviour {

	// Use this for initialization
    public AudioSource AS;
    public bk_AudioManager AM;

	void Start ()
	{
	    AS = FindObjectOfType<AudioSource>();
        AM = FindObjectOfType<bk_AudioManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AS.clip = AM.listOfThemes[1];
            AS.Play();
        }
    }
}
