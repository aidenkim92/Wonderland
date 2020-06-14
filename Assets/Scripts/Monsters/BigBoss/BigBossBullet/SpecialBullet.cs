using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class SpecialBullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 10;
    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.Self);
    }

    void OnTriggerEnter2D(Collider2D collision)
    { 
       if (collision.gameObject.tag == "Player")
      {
            Player.instance.Damage(damage);
           Destroy(gameObject);
       }
    }
}
