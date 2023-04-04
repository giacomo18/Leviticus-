using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class Sound : MonoBehaviour
{

    [SerializeField] Slider musicSlider;
    [SerializeField] GameObject prefs;
    [SerializeField] AudioSource musicSource;

    private void Awake()
    {
        prefs = GameObject.Find("PlayerData");
        musicSource = prefs.GetComponent<AudioSource>();
    }

    void Start()
    {
        Load();
    }

    public void ChangeVolume()
    {
        musicSource.volume = musicSlider.value;
        Save();
    }

    private void Load()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
    }
}
