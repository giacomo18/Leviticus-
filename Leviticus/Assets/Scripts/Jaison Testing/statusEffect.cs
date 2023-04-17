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

    public playerManager playerManager;

    [SerializeField] iconStuff iconStuff;

    [SerializeField] Text fireText;
    [SerializeField] Text poisonText;
    [SerializeField] Text stunText;
    [SerializeField] Text healOverTimeText;
    [SerializeField] Text powerfulText;

    private int fireAmount;
    private int poisonAmount;
    private int stunAmount;
    private int powerfulAmount;
    private int healOverTimeAmount;




    public void Effect(int Effect)
    {
        if(Effect == 1)
        {
            playerManager.playerHealthValue -= 10;
            playerManager.playerHealth.UpdateMeter(playerManager.playerHealthValue, playerManager.playerMaxHealthValue);
          
            iconStuff.effectValue = 1;
 
            iconStuff.Icon();
            fireAmount += 1;
            if (iconStuff.fire.enabled)
            {
                fireText.text = (fireAmount.ToString());
            }
          
        }
        if (Effect == 2)
        {
            playerManager.playerHealthValue -= 0.1f;
            playerManager.playerHealth.UpdateMeter(playerManager.playerHealthValue, playerManager.playerMaxHealthValue);

            iconStuff.effectValue = 2;

            iconStuff.Icon();
            poisonAmount += 1;
            if (iconStuff.poison.enabled)
            {
                poisonText.text = (poisonAmount.ToString());
            }
        }

        if(Effect == 3)
        {
            iconStuff.effectValue = 3;

            iconStuff.Icon();
            stunAmount += 1;
            if (iconStuff.stun.enabled)
            {
                stunText.text = (stunAmount.ToString());
            }
        }
        if (Effect == 4)
        {
            iconStuff.effectValue = 4;

            iconStuff.Icon();
            healOverTimeAmount += 1;
            if (iconStuff.healOverTime.enabled)
            {
                healOverTimeText.text = (healOverTimeAmount.ToString());
            }
        }
        if (Effect == 5)
        {
            iconStuff.effectValue = 5;

            iconStuff.Icon();
            powerfulAmount += 1;
            if (iconStuff.powerful.enabled)
            {
                powerfulText.text = (powerfulAmount.ToString());
            }
        }

    }
}
