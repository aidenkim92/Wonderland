using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyD : MonoBehaviour
{
    //This damage collider is in the prefab.
    //If the explosion damage needs to be adjusted then instantiate this prefab to the  Hierarchy first.
    //Then open the prefab to the adjust the damage in the Collider object!
    public int damage;
    public GameObject go;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BorderBullet" && collision.gameObject.tag == "Border")
        {
            Destroy(go);
        }
        if (collision.gameObject.tag == "Player")
        { 
             Player.instance.Damage(damage);
             Destroy(go);
        }
    }
}
