using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBossCollider : MonoBehaviour
{
    //When the player is actually collide with the big boss
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Player.instance.Damage(100);
        }
    }
}
