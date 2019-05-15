using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bk_AudioManager : MonoBehaviour
{
    public static bk_AudioManager instance;

    public AudioSource[] audioSourceComponents;

    public AudioSource themePlayer;
    public AudioSource soundPlayer;

    public AudioClip[] listOfThemes;
    public AudioClip[] listOfSoundeffects;

    void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        audioSourceComponents = GetComponents<AudioSource>();

        themePlayer = audioSourceComponents[0];
        soundPlayer = audioSourceComponents[1];
    }
    // Use this for initialization
    void Start ()
    {
        themePlayer.clip = listOfThemes[0];
        themePlayer.Play();
        DontDestroyOnLoad(gameObject);
	}
	
}
