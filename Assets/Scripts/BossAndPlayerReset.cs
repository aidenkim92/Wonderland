using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAndPlayerReset : MonoBehaviour
{

    //private BigBoss boss;
    private Player player;
    public Transform respawnPos;
    // Start is called before the first frame update
    void Start()
    {
        //boss = FindObjectOfType<BigBoss>();
        player = FindObjectOfType<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.curHealth<= 0)
        {
           //LevelManager.instance.RespawnPlayer();
            //LevelManager.instance.RespawnPlayerForBoss(respawnPos);
            //boss.health = boss.maxHealth;
        }
        
    }
}
