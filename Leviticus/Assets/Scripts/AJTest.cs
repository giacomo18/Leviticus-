using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AJTest : MonoBehaviour
{
    PlayerPreferences playerPrefs;
    public GameObject uiPreset1;
    public GameObject uiPreset2;
    public GameObject uiPreset3;
    public GameObject enemyChar;
    public GameObject playerChar;

    //Preset 1 Objects
    public GameObject Pr1_ActionBar;
    public GameObject Pr1_PlayerHealth;
    public GameObject Pr1_EnemyHealth;

    //Preset 3 Objects
    public GameObject Pr3_PlayerHealth;
    public GameObject Pr3_EnemyHealth;
    public GameObject Pr3_ActionBar;
    public GameObject Pr3_ManaBar;


    void Start()
    {
        playerPrefs = GameObject.Find("PlayerData").GetComponent<PlayerPreferences>();
    }

    public void Scale1()
    {
        if(playerPrefs.hudTypePref == 3)
        {
            Preset3Change(0.8f);
        }
        else if(playerPrefs.hudTypePref == 2)
        {
            Preset2Change(0.8f);
        }
        else
        {
            Preset1Change(0.8f);
        }

    }

    public void Scale2()
    {
        if (playerPrefs.hudTypePref == 3)
        {
            Preset3Change(1f);
        }
        else if (playerPrefs.hudTypePref == 2)
        {
            Preset2Change(1f);
        }
        else
        {
            Preset1Change(1f);
        }
    }

    public void Scale3()
    {
        if (playerPrefs.hudTypePref == 3)
        {
            Preset3Change(1.2f);
        }
        else if (playerPrefs.hudTypePref == 2)
        {
            Preset2Change(1.2f);
        }
        else
        {
            Preset1Change(1.2f);
        }
    }

    public void Preset1Change(float value)
    {
        Pr1_EnemyHealth.transform.localScale = new Vector2(value, value);
        Pr1_PlayerHealth.transform.localScale = new Vector2(value, value);
        Pr1_ActionBar.transform.localScale = new Vector2(value, value);
    }

    public void Preset2Change(float value)
    {
        uiPreset2.transform.localScale = new Vector2(value, value);
    }

    public void Preset3Change(float value)
    {
        //Player, Enemy, PlayerHealthBar, EnemyHealthBar, ActionBar;
        Pr3_PlayerHealth.transform.localScale = new Vector2(value, value);
        Pr3_EnemyHealth.transform.localScale = new Vector2(value, value);
        Pr3_ActionBar.transform.localScale = new Vector2(value, value);
        Pr3_ManaBar.transform.localScale = new Vector2(value, value);
    }
}
