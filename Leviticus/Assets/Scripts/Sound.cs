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

    private void Awake()
    {
        pData = GameObject.Find("PlayerData");
        musicSource = pData.GetComponent<AudioSource>();
        sfxCtrl = GameObject.Find("SFXController");
        sfxSource = sfxCtrl.GetComponent<AudioSource>();
    }

    void Start()
    {
        Load();
    }

    public void ChangeVolume()
    {
        musicSource.volume = musicSlider.value;
        sfxSource.volume = sfxSlider.value;
        Save();
    }

    private void Load()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("sfxVolume", sfxSlider.value);
    }
}
