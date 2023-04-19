using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enemyManager enemyManager;
    public playerManager playerManager;

    [SerializeField] Animator Anim;
    public bool enemyDefeated;

    public int enemyFire;
    public int enemyPoison;
    public int enemyStun;
    public int enemyHeal;
    public int enemyPower;

    public int playerFire;
    public int playerPoison;
    public int playerStun;
    public int playerHeal;
    public int playerPower;

    private void Start()
    {
        playerManager.playerStart();
        enemyDefeated = false;
    }

    public void playerTurn()
    {
        if(playerManager.playerHealthValue > 0)
        {
            playerManager.playerStart();
        }
        else
        {
            Lose();
        }

    }

    public void EnemyStart()
    {
        if (enemyManager.enemyHealth > 0)
        {
            enemyManager.enemyTurn();

        }
        else
        {
            Anim.SetTrigger("Death");
        }

    }

    public void Won()
    {
        if (enemyManager.enemyHealth <= 0)
        {
           enemyDefeated = true;
           //win screen here
        }
        
    }


    public void Lose()
    {
        SceneManager.LoadScene("Lose Condition");
    }



}
