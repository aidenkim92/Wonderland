using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    //Variable for spawn enemy 
    public int health;
    public float speed;

    //Reference to get physics
    Rigidbody2D rigid;
    
    //Update the frame per second
    void Update()
    {
        //If the player health is bigger than 0
        if(Player.instance.curHealth > 0)
        {
            //Move the bullets towards to the player
            transform.position = Vector3.MoveTowards(transform.position, Player.instance.transform.position, speed * Time.deltaTime);
        }
        //If big boss is destroyed
        if (UIManager.instance.bigBossHealthBar.value == 0)
        {
            Destroy(gameObject);
        }

    }

    //Initialize
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.zero * speed;
    }

    //Damage method when it gets damaged by the player
    void Damage(int damage)
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        health -= damage;
    }
}
