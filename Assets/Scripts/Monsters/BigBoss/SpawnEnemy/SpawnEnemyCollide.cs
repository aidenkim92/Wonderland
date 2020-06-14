using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyCollide : MonoBehaviour
{
    //This damage collider is in the prefab.
    //If the explosion damage needs to be adjusted then instantiate this prefab to the  Hierarchy first.
    //Then open the prefab to the adjust the damage in the Collider object!
    public int damage;

    //Reference the spawn enemy object
    public GameObject go;

    //Reference explossion effect prefab
    public GameObject explosionEffect;

    //Trigger method for giving damage to the player or should be destroyed
    //when it collide with certain objects
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border" || collision.gameObject.tag == "PlatForm")
        {
            Destroy(go);
        }
        if(collision.gameObject.tag == "Player")
        {
            Player.instance.Damage(damage);
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(go);
        }
    }
}
