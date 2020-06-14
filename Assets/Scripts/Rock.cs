using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{

    private Rigidbody2D rb;
    private Player player;
    private Vector3 originalPos;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);


    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y >= -100)
        {
            gameObject.transform.position = originalPos;

        }

       


    }

  

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            {
            rb.isKinematic = false;

        }

    }
}
