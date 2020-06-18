using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class: Rock class represents a Rock trap Monster in game
 * It controls its movement functionality
 * @Author Shahil Khan**/
public class Rock : MonoBehaviour
{
    //Variables
    private Rigidbody2D rb;
    public Player player;
    private Vector3 originalPos;
    private bool isFallen;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {}

    /**
     * Function: resetPosition() resets the position of the Rock object when called*/
    public void resetPosition()
    {
        gameObject.transform.position = originalPos;
        rb.isKinematic = true;
        isFallen = false;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
  
    /**
     * Function: onTriggerEnter2D(Collider2D collision) checks if an object has collided with the Rock
     * When the object is a player, it plays a falling down sound and starts falling down.*/
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isFallen)
        {
            AudioManager.instance.PlaySFX(8);
            rb.isKinematic = false;
            isFallen = true;

        }
    }
}
