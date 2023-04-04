using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPreferences : MonoBehaviour
{
    [SerializeField] OptionsManager options;
    [SerializeField] int hudTypePref;

    // Start is called before the first frame update
    void Start()
    {
        options = GameObject.Find("EventSystem").GetComponent<OptionsManager>();
    }

    public void SaveData()
    {
        //PlayerPrefs.SetInt("hudType", options);
    }

    void LoadData()
    {
        hudTypePref = PlayerPrefs.GetInt("hudType");
    }
}
