using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour {

    private Slider musicSlider;
    public bk_AudioManager audioManager;

    private void Awake()
    {
        musicSlider = GetComponent<Slider>();
        audioManager = GameObject.FindObjectOfType<bk_AudioManager>();

    }
    // Use this for initialization
    void Start () {

        musicSlider.onValueChanged.AddListener(audioManager.MusicChange);
        print("以家");
    }

    private void OnEnable()
    {
        //musicSlider.value = PlayerPrefs.GetFloat("option");

    }

}
