using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPreferences : MonoBehaviour
{
    public int hudTypePref;
    public int hudScalePref;

    void Start()
    {
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
    }
}
