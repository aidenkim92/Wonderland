using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerB : MonoBehaviour
{
    public GameObject[] enemyObjs;
    public Transform[] spawnPoints;

    public float maxSpawnDelay;
    public float curSpawnDelay;

     void Update()
    {
        curSpawnDelay += Time.deltaTime;

        if(curSpawnDelay > maxSpawnDelay && Player.instance.curHealth >0)
        {
            SpawnEnemy();
            maxSpawnDelay = Random.Range(0.5f, 3f);
            curSpawnDelay = 0;
        }
    }

    void SpawnEnemy()
    {
        int randEnemy = Random.Range(0, 3);
        int randPoint = Random.Range(0, 5);
        Instantiate(enemyObjs[randEnemy], spawnPoints[randPoint].position, spawnPoints[randPoint].rotation);
        
    }
}
