using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerB : MonoBehaviour
{
    //Reference for prefab of the enemies
    public GameObject[] enemyObjs;
    //Reference for spawn points
    public Transform[] spawnPoints;

    //Variables for spawn delay time
    public float maxSpawnDelay;
    public float curSpawnDelay;

    //Update the frame per second
     void Update()
    {
        //Delay time for spawn the enemy
        curSpawnDelay += Time.deltaTime;

        //If the spawn delay is smaller than max spawn delay time
        //And player current health is bigger than 0
        //then it should spawn the enemy 
        if(curSpawnDelay > maxSpawnDelay && Player.instance.curHealth >0 && UIManager.instance.bigBossHealthBar.value > 0)
        {
            SpawnEnemy();
            maxSpawnDelay = Random.Range(0.5f, 3f);
            curSpawnDelay = 0;
        }
    }

    //For spawn the enemy at the specific points
    //And for instantiate the enemy prefabs
    void SpawnEnemy()
    {
        int randEnemy = Random.Range(0, 3);
        int randPoint = Random.Range(0, 5);
        Instantiate(enemyObjs[randEnemy], spawnPoints[randPoint].position, spawnPoints[randPoint].rotation);
        
    }
}
