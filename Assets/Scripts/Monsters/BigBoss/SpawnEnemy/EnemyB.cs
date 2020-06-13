using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB : MonoBehaviour
{
    public int health;
    public float speed;
    Rigidbody2D rigid;
    
    void Update()
    {
        if(Player.instance.curHealth > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.instance.transform.position, speed * Time.deltaTime);
        }

    }
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.zero * speed;
    }
    void Damage(int damage)
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        health -= damage;
    }
}
