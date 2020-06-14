using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBossBullet : MonoBehaviour
{
    public int damage;
    public bool isRotate;

    void Update()
    {
        if(isRotate)
        {
            transform.Rotate(Vector3.forward * 10);
        }
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Border" || collision.gameObject.tag == "PlatForm")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Player")
        { 
            Player.instance.Damage(damage);
            Destroy(gameObject);
        }
    }
}
