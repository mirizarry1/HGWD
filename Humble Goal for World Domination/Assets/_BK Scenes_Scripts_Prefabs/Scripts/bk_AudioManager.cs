using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bk_AudioManager : MonoBehaviour
{
    public static bk_AudioManager instance;

    public AudioSource[] audioSourceComponents;

    public AudioSource themePlayer;
    public AudioSource soundPlayer;

    public AudioClip[] listOfThemes;
    public AudioClip[] listOfSoundeffects;

    //******************************
    public Slider musicSlider;
    private float musicVolume;
    //******************************

    void Awake()
    {
        

        if (instance==null)
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
        //************************
        musicSlider = GameObject.FindObjectOfType<SliderHolder>().musicSlider;
        themePlayer.volume = PlayerPrefs.GetFloat("option");
        musicVolume = PlayerPrefs.GetFloat("option");
        musicSlider.value = musicVolume;
        //************************
        themePlayer.clip = listOfThemes[0];
        themePlayer.Play();
        DontDestroyOnLoad(gameObject);
	}
	
    public void MusicChange(float non)
    {
        musicVolume = musicSlider.value;
        themePlayer.volume = musicVolume;
        PlayerPrefs.SetFloat("option", musicVolume);
    }

    private void OnLevelWasLoaded(int level)
    {
        musicSlider = GameObject.FindObjectOfType<SliderHolder>().musicSlider;
        themePlayer.volume = PlayerPrefs.GetFloat("option");
        musicVolume = PlayerPrefs.GetFloat("option");
        musicSlider.value = musicVolume;
    }
}
