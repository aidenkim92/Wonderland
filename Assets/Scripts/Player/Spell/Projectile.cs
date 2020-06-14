using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed = 10f;
    public int damage = 25;
    public GameObject impactEffect;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * projectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            Debug.Log(collision.tag);
            GameObject clone = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject); //Destroys the bullet
            Destroy(clone, 1f);  //Destroys the effect clone after animation(time)
            //If the trriggered
            if ((collision.isTrigger != true) && collision.CompareTag("Enemy"))
            {
                //then sendThe damage to the Mathod Damage in the monster whose has the Damage mathod
                collision.SendMessageUpwards("Damage", damage);
            }
            else if ((collision.isTrigger == true) && collision.CompareTag("Boss"))
            {
                collision.SendMessageUpwards("Damage", damage);
            }
            else if((collision.isTrigger == true) && collision.CompareTag("BigBoss"))
            {
                collision.SendMessageUpwards("Damage", damage);
            }
            
        }
    }
}
