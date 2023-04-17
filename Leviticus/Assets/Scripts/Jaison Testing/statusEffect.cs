using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statusEffect : MonoBehaviour
{
    [SerializeField] Button fire;
    [SerializeField] Button poison;
    [SerializeField] Button Stun;
    [SerializeField] Button healOverTime;
    [SerializeField] Button powerful;

    [SerializeField] Slider playerHealth;
    [SerializeField] float playerHealthValue;
    [SerializeField] float playerMaxHealthValue;


    public void Effect(int Effect)
    {
        if(Effect == 1)
        {
            playerHealthValue -= 10;
        }
        if (Effect == 2)
        {
            playerHealthValue -= 0.1f;
        }
        
    }
}
