using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    public playerManager playerManager;
    public HealthBarScript enemyHealthBar;
    public GameManager gameManager;

    public int enemyHealth;
    public int enemyMaxHealth;
    [SerializeField] int enemyMinDamage = 10;
    [SerializeField] int enemyMaxDamage = 10;
    private bool alive = true;
    private bool isCoroutineOn;
    private int Action;

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
            playerManager.playerHealth.UpdateMeter(playerManager.playerHealthValue, playerManager.playerMaxHealthValue);
        }
        if(Action == 2)
        {

        }

    }
}
