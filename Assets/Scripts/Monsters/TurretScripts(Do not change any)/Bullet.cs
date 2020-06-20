using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.isTrigger != true)
        {
            if(col.CompareTag("SidePlatForm") || col.CompareTag("PlatForm"))
            {
                Destroy(gameObject);
            }
            if(col.CompareTag("Player"))
            {
                col.GetComponent<Player>().Damage(1);// <- need to be added when me(Aiden) add the health bar
                Destroy(gameObject);
            }
           
        }
    }
}
