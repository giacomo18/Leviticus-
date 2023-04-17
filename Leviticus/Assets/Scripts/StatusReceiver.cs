using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StatusReceiver : MonoBehaviour
{
    public Image fire;
    public Image poison;
    public Image stun;
    public Image healOverTime;
    public Image powerful;

    public playerManager playerManager;

    [SerializeField] TextMeshProUGUI fireText;
    [SerializeField] TextMeshProUGUI poisonText;
    [SerializeField] TextMeshProUGUI stunText;
    [SerializeField] TextMeshProUGUI healOverTimeText;
    [SerializeField] TextMeshProUGUI powerfulText;

    private int fireAmount;
    private int poisonAmount;
    private int stunAmount;
    private int powerfulAmount;
    private int healOverTimeAmount;



    private void Start()
    {
        fire.enabled = false;
        poison.enabled = false;
        stun.enabled = false;
        healOverTime.enabled = false;
        powerful.enabled = false;
    }



    public void Fire()
    {
        playerManager.playerHealthValue -= 10;
        playerManager.playerHealth.UpdateMeter(playerManager.playerHealthValue, playerManager.playerMaxHealthValue);


        
        fireAmount += 1;
        if (fire.enabled)
        {
            fireText.text = (fireAmount.ToString());
        }

    }

    public void Poison()
    {
        playerManager.playerHealthValue -= 0.1f;
        playerManager.playerHealth.UpdateMeter(playerManager.playerHealthValue, playerManager.playerMaxHealthValue);

       
               
        poisonAmount += 1;
        if (poison.enabled)
        {
            poisonText.text = (poisonAmount.ToString());
        }
    }

    public void Stun()
    {
        stunAmount += 1;
        if (stun.enabled)
        {
            stunText.text = (stunAmount.ToString());
        }
    }

    public void HoT()
    {
        healOverTimeAmount += 1;
        if (healOverTime.enabled)
        {
            healOverTimeText.text = (healOverTimeAmount.ToString());
        }
    }

    public void Powerful()
    {
        powerfulAmount += 1;
        if (powerful.enabled)
        {
            powerfulText.text = (powerfulAmount.ToString());
        }
    }


}
