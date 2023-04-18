using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGenerator : MonoBehaviour
{
    [SerializeField] int numberSpawned;
    [SerializeField] int minSpawned;
    [SerializeField] int maxSpawned;




    [SerializeField] GameObject spawnedEnemy;

    [SerializeField] GameObject enemyType;

    //Number of enemy
    public List<GameObject> amount = new List<GameObject>();
    //Enemy Type
    public List<GameObject> Type = new List<GameObject>();

    //Enemy types
    [SerializeField] GameObject skeleton;
    [SerializeField] GameObject Wolf;


    private void Start()
    {

        Type[0] = skeleton;

        Type[1] = Wolf;
    }
    public void EnemyGeneration()
    {
        numberSpawned = Random.Range(minSpawned, maxSpawned);
        Debug.Log("L boxo)");

        for (int i = 0; i < numberSpawned; i++)
        {
            enemyType = Type[Random.Range(0, Type.Count)];
            {
               // enemyType = Instantiate(enemyType, new Vector2(( / (numberSpawned + 1)) * (i + 1), -15), Quaternion.identity);
                enemyType.transform.SetParent(transform, false);
                amount.Add(enemyType);
            }
        }
    }

}
