using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour
{
    public enemyManager enemyManager;
    public playerManager playerManager;
    public enemyGenerator enemyGenerator;

    [SerializeField] Animator Anim;




    private void Start()
    {
        enemyGenerator.EnemyGeneration();
        playerManager.playerStart();
    }

    public void playerTurn()
    {
        if (playerManager.playerHealthValue > 0)
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


    public void Lose()
    {
        SceneManager.LoadScene("Lose Condition");
    }


}
