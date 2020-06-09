using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB : MonoBehaviour
{
    public int health;
    public float speed;
    public float playerRange;
   
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;
    public Sprite[] sprites;

    void Update()
    {
        if(Player.instance.curHealth > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.instance.transform.position, speed * Time.deltaTime);
        }

    }
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * speed;
    }
    void Damage(int damage)
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        health -= damage;
    }
    void ReturnSprite()
    {
        spriteRenderer.sprite = sprites[0];
    }
}
