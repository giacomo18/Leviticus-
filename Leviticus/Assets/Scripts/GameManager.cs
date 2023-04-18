using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enemyManager enemyManager;
    public playerManager playerManager;




    private void Start()
    {
        playerManager.playerStart();
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
        enemyManager.enemyTurn();
    }


    public void Lose()
    {
        SceneManager.LoadScene("Lose Condition");
    }



}
