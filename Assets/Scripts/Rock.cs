using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{

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

    public void resetPosition()
    {
        gameObject.transform.position = originalPos;
        rb.isKinematic = true;
        isFallen = false;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
  

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
