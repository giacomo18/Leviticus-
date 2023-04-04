using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    GameObject pData;
    GameObject sfxCtrl;
    AudioSource musicSource;
    AudioSource sfxSource;
    PlayerPreferences prefs;

    private void Awake()
    {
        pData = GameObject.Find("PlayerData");
        musicSource = pData.GetComponent<AudioSource>();
        sfxCtrl = GameObject.Find("SFXController");
        sfxSource = sfxCtrl.GetComponent<AudioSource>();
        prefs = pData.GetComponent<PlayerPreferences>();
    }

    void Start()
    {
        Load();
    }

    //private void Update()
    //{
    //  Save();
    //}

    public void ChangeMusicVolume()
    {
        musicSource.volume = musicSlider.value;
        SaveMusic();
    }

    public void ChangeSFXVolume()
    {
        sfxSource.volume = sfxSlider.value;
        SaveSFX();
    }

    private void Load()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
    }

    private void SaveMusic()
    {
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
        prefs.musicSource.volume = PlayerPrefs.GetFloat("musicVolume");
    }
    private void SaveSFX()
    {
        PlayerPrefs.SetFloat("sfxVolume", sfxSlider.value);
        prefs.sfxSource.volume = PlayerPrefs.GetFloat("sfxVolume");
    }
}
