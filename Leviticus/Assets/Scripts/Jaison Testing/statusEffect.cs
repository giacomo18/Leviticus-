using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class statusEffect : MonoBehaviour
{
    [SerializeField] Button fire;
    [SerializeField] Button poison;
    [SerializeField] Button Stun;
    [SerializeField] Button healOverTime;
    [SerializeField] Button powerful;

    [SerializeField] propertyMeter playerHealth;
    [SerializeField] float playerHealthValue;
    [SerializeField] float playerMaxHealthValue = 100;


    public void Effect(int Effect)
    {
        if(Effect == 1)
        {
            playerHealthValue -= 10;
            playerHealth.UpdateMeter(playerHealthValue, playerMaxHealthValue);
        }
        if (Effect == 2)
        {
            playerHealthValue -= 0.1f;
        }
        
    }
}
