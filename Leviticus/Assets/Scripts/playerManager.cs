using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerManager : MonoBehaviour
{
    public HealthBarScript playerHealthBar;
    [SerializeField] enemyManager enemyManager;
    [SerializeField] GameManager gameManager;
    [SerializeField] PlayerPreferences playerPreferences;

    public float playerHealthValue;
    public float playerMaxHealthValue = 100;


    
    [SerializeField] int playerDamage;
    [SerializeField] Button Action1;
    [SerializeField] Button Action2;
    [SerializeField] Button Action3;

    [SerializeField] Animator anim;
    




    private void Start()
    {
        playerPreferences = GameObject.Find("PlayerData").GetComponent<PlayerPreferences>();
        //Pref 3
        if (playerPreferences.hudTypePref == 3)
        {
            Action1 = GameObject.Find("P3Attack").GetComponent<Button>();
            Action2 = GameObject.Find("P3Action").GetComponent<Button>();
            Action3 = GameObject.Find("P3End").GetComponent<Button>();
            playerHealthBar = GameObject.Find("P1playerHealthBar").GetComponent<HealthBarScript>();

        }
        //Pref 2
        else if (playerPreferences.hudTypePref == 2)
        {
            Action1 = GameObject.Find("P2Attack").GetComponent<Button>();
            Action2 = GameObject.Find("P2Action").GetComponent<Button>();
            Action3 = GameObject.Find("P2End").GetComponent<Button>();
            playerHealthBar = GameObject.Find("P2playerHealthBar").GetComponent<HealthBarScript>();
        }
        //Pref1
        else
        {
            Action1 = GameObject.Find("P1Attack").GetComponent<Button>();
            Action2 = GameObject.Find("P1Action").GetComponent<Button>();
            Action3 = GameObject.Find("P1End").GetComponent<Button>();
            playerHealthBar = GameObject.Find("P3playerHealthBar").GetComponent<HealthBarScript>();
        }
    }

    public void playerStart()
    {
        Action1.interactable = true;
        Action2.interactable = true;
        Action3.interactable = true;
    }


    public void playerAction(int Button)
    {
       if(Button == 0)
        {
            enemyManager.enemyHealth -= playerDamage;
            enemyManager.enemyHealthBar.UpdateMeter(enemyManager.enemyHealth, enemyManager.enemyMaxHealth);
            anim.SetTrigger("attack");

        }
       if(Button == 1)
        {
            //idk, heal maybe? 
        }
       if(Button== 2)
        {
            Action1.interactable = false;
            Action2.interactable = false;
            Action3.interactable = false;

            gameManager.EnemyStart();
        }
    }

}
