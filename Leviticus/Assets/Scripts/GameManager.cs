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

    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject charPlayer;
    public GameObject charEnemy;

    private void Start()
    {
        playerManager.playerStart();
        enemyDefeated = false;

        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        charPlayer.SetActive(true);
        charEnemy.SetActive(true);
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
            Won();
        }

    }

    public void Won()
    {
        if (enemyManager.enemyHealth <= 0)
        {
           enemyDefeated = true;
           winScreen.SetActive(true);
           charPlayer.SetActive(false);
           charEnemy.SetActive(false);
        }
    }


    public void Lose()
    {
        loseScreen.SetActive(true);
        charPlayer.SetActive(false);
        charEnemy.SetActive(false);
    }

    public void NextRound()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
