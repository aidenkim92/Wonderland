using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class SpecialBullet : MonoBehaviour
{
    //Variables for the bullets
    public float speed = 10f;
    public int damage = 10;
 
    //When it starts the bullet is destroyed after 2seconds
    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    private void Update()
    {
        //It prevents happen the error for rotating bullets
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.Self);

        //If big boss is destroyed
        if (UIManager.instance.bigBossHealthBar.value == 0)
        {
            Destroy(gameObject);
        }
    }

    //Trigger method for giving damage
    void OnTriggerEnter2D(Collider2D collision)
    { 
       if (collision.gameObject.tag == "Player")
       {
            Player.instance.Damage(damage);
           Destroy(gameObject);
       }
    }
}
