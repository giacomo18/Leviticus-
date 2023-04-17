using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerManager : MonoBehaviour
{
    public HealthBarScript playerHealth;
    [SerializeField] enemyManager enemyManager;
    [SerializeField] GameManager gameManager;

    public float playerHealthValue;
    public float playerMaxHealthValue = 100;


    
    [SerializeField] int playerDamage;
    [SerializeField] Button Action1;
    [SerializeField] Button Action2;
    [SerializeField] Button Action3;

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

        }
       if(Button == 1)
        {
            //idk, heal maybe? 
        }
       if(Button== 2)
        {
            //something with game controller
            //something with enemy controller
            //probably
            //enemyManager.enemyController.enemyTurn()
            Action1.interactable = false;
            Action2.interactable = false;
            Action3.interactable = false;
            gameManager.EnemyStart();

        }
    }

}
