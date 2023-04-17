using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        playerManager.playerStart();
    }

    public void EnemyStart()
    {
        enemyManager.enemyTurn();
    }
}
