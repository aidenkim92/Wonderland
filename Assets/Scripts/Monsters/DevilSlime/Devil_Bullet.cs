using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Devil_Bullet : MonoBehaviour
{
    public float speed;
    public bool isDestroyed = false;
    Player player;
    Rigidbody2D rb;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();
        fire();
    }

    // Update is called once per frame
    void fire()
    {

        rb.velocity = (player.transform.position - rb.transform.position).normalized * speed;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.isTrigger != true)
        {
            if (other.gameObject.tag == ("Player"))
            {

                other.GetComponent<Player>().Damage(10);
                Destroy(gameObject);
                isDestroyed = true;
            }
        }

    }
}
