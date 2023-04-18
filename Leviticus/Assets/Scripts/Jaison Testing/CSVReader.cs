using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CSVReader : MonoBehaviour
{
    public TextAsset textAssetData;


    [System.Serializable]
    public class Enemy
    {
        public string name;
        public int Health;
        public int minDamage;
        public int maxDamage;

    }

    [System.Serializable]
    public class EnemyList
    {
        public Enemy[] enemy;
    }

    public EnemyList myEnemyList = new EnemyList();

    void Start()
    {
        ReadCSV();
    }


    void ReadCSV()
    {
        string[] data = textAssetData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        int tableSize = data.Length / 7 - 1;
        myEnemyList.enemy = new Enemy[tableSize];

        for(int i = 0; i < tableSize; i++)
        {
            myEnemyList.enemy[i] = new Enemy();
            myEnemyList.enemy[i].name = data[4 * (i + 1)];
            myEnemyList.enemy[i].Health = int.Parse(data[4 * (i + 1) + 1]);
            myEnemyList.enemy[i].minDamage = int.Parse(data[4 * (i + 1) + 2]);
            myEnemyList.enemy[i].maxDamage = int.Parse(data[4 * (i + 1) + 3]);

        }
    }

}
