using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed = 10f;
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
        }
    }
}
