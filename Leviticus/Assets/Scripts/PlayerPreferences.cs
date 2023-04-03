using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPreferences : MonoBehaviour
{
    public GameObject playerPrefManager;
    public int hudTypePref;
    public Options options;
    public GameObject optionsObj;

    // Start is called before the first frame update
    void Start()
    {
        hudTypePref = 1;
        LoadData();
        optionsObj = GameObject.Find("EventSystem");
    }

    // Update is called once per frame
    void Update()
    {
        options = FindObjectOfType<Options>();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("hudType", options.uiTypePref);
    }

    void LoadData()
    {
        hudTypePref = PlayerPrefs.GetInt("hudType");
    }
}
