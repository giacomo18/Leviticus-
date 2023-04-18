using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGenerator : MonoBehaviour
{
    [SerializeField] int numberSpawned;
    [SerializeField] int minSpawned;
    [SerializeField] int maxSpawned;


    [SerializeField] GameObject spawnedEnemy;
    [SerializeField] GameObject spawnpoint1;
    [SerializeField] GameObject spawnpoint2;
    [SerializeField] GameObject spawnpoint3;



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


        if (numberSpawned == 1)
        {
            enemyType = Type[Random.Range(0, Type.Count)];
            //spawnpoint1 = enemyType;
            enemyType = Instantiate(enemyType, spawnpoint1.transform);
            Debug.Log(enemyType);
            spawnpoint2.SetActive(false);
            spawnpoint3.SetActive(false);
        }
        else if (numberSpawned == 2)
        {
            enemyType = Type[Random.Range(0, Type.Count)];
            enemyType = Instantiate(enemyType, spawnpoint1.transform);
            enemyType = Type[Random.Range(0, Type.Count)];
            enemyType = Instantiate(enemyType, spawnpoint2.transform);
         

            spawnpoint3.SetActive(false);
        }
        else
        {
            enemyType = Type[Random.Range(0, Type.Count)];
            enemyType = Instantiate(enemyType, spawnpoint1.transform);
            enemyType = Type[Random.Range(0, Type.Count)];
            enemyType = Instantiate(enemyType, spawnpoint2.transform);
            enemyType = Type[Random.Range(0, Type.Count)];
            enemyType = Instantiate(enemyType, spawnpoint3.transform);

        }

        /*
        for (int i = 0; i < numberSpawned; i++)
        {
            enemyType = Type[Random.Range(0, Type.Count)];
            {
               enemyType = Instantiate(enemyType, new Vector2((15 / (numberSpawned + 1)) * (i + 1), 1f), Quaternion.identity);
                enemyType.transform.SetParent(transform, false);
                amount.Add(enemyType);
            }
        }
        */
    }

}
