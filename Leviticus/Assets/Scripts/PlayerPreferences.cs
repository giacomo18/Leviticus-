using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPreferences : MonoBehaviour
{
    public int hudTypePref;
    public int hudScalePref;
    public float musicVolume;
    public float sfxVolume;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    void Start()
    {
        musicSource.volume = PlayerPrefs.GetFloat("musicVolume");
        sfxSource.volume = PlayerPrefs.GetFloat("sfxVolume");
        LoadData();
    }

    public void SaveType(int typeNum)
    {
        PlayerPrefs.SetInt("hudType", typeNum);
        LoadData();
    }

    public void SaveScale(int scaleNum)
    {
        PlayerPrefs.SetInt("hudScale", scaleNum);
        LoadData();
    }

    void LoadData()
    {
        hudTypePref = PlayerPrefs.GetInt("hudType");
        hudScalePref = PlayerPrefs.GetInt("hudScale");
        musicVolume = PlayerPrefs.GetFloat("musicVolume");
        sfxVolume = PlayerPrefs.GetFloat("sfxVolume");
    }
}
