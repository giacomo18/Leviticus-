using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class enemyManager : MonoBehaviour
{
    public playerManager playerManager;
    public HealthBarScript enemyHealthBar;
    public GameManager gameManager;
    [SerializeField] PlayerPreferences playerPreferences;

    public int enemyHealth;
    public int enemyMaxHealth;
    [SerializeField] int enemyMinDamage = 10;
    [SerializeField] int enemyMaxDamage = 10;
    private bool alive = true;
    private bool isCoroutineOn;
    private int Action;

    [SerializeField] Animator Anim;


    private void Start()
    {
        playerPreferences = GameObject.Find("PlayerData").GetComponent<PlayerPreferences>();
        //Pref 3
        if (playerPreferences.hudTypePref == 3)
        {
            enemyHealthBar = GameObject.Find("P1enemyHealthBar").GetComponent<HealthBarScript>();

        }
        //Pref 2
        else if (playerPreferences.hudTypePref == 2)
        {
            enemyHealthBar = GameObject.Find("P2enemyHealthBar").GetComponent<HealthBarScript>();
        }
        //Pref1
        else
        {
            enemyHealthBar = GameObject.Find("P3enemyHealthBar").GetComponent<HealthBarScript>();
        }
    }
    public void enemyTurn()
    {
        if (alive == true)
        {
            StartCoroutine(Delay(3));
        }
    }


    IEnumerator Delay(float time)
    {
        if (isCoroutineOn)
            yield break;

        isCoroutineOn = true;

        yield return new WaitForSeconds(time);
        enemyAction();

        gameManager.playerTurn();
        isCoroutineOn = false;


    }

    public void enemyAction()
    {
        Action = Random.Range(0, 3);
        Debug.Log(Action);
        if(Action == 0)
        {
            playerManager.playerHealthValue -= Random.Range(enemyMinDamage, enemyMaxDamage);
            playerManager.playerHealthBar.UpdateMeter(playerManager.playerHealthValue, playerManager.playerMaxHealthValue);
            Anim.SetTrigger("Attack");
        }
        if(Action == 2)
        {
            
        }

    }
}
