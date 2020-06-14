using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBossBullet : MonoBehaviour
{
    //Variables for bullet status
    public int damage;
    public bool isRotate;

    //Update the frame per second
    void Update()
    {
        //If the bullet is rotating
        if(isRotate)
        {
            //Move the bullets with multiplying 10 magnitude
            transform.Rotate(Vector3.forward * 10);
        }
        //If big boss is destroyed
        if (UIManager.instance.bigBossHealthBar.value == 0)
        {
            Destroy(gameObject);
        }
    }

    //Trigger method for giving damage or eliminated when the collide with the certain obejects
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
