using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPreferences : MonoBehaviour
{
    public int hudTypePref;

    void Start()
    {
        LoadData();
    }

    public void SaveData(int hudNum)
    {
        PlayerPrefs.SetInt("hudType", hudNum);
        LoadData();
    }

    void LoadData()
    {
        hudTypePref = PlayerPrefs.GetInt("hudType");
    }
}
