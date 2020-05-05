using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    private Collider2D coll;
    private Rigidbody2D rb;
    private Animator anim;


    [SerializeField] public LayerMask ground;


    [SerializeField] public float leftCap;
    [SerializeField] public float rightCap;

    [SerializeField] public float jumpLength;
    [SerializeField] public float jumpHeight;

    private bool facingRight = true;

    private void Start()
    {

        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
               
    }


    private void Update()
    {
        if (anim.GetBool("Jumping"))
        {
            if (rb.velocity.y < .1f)
            {
                anim.SetBool("Falling", true);
                anim.SetBool("Jumping", false);
            }
        }
        if (coll.IsTouchingLayers(ground) && anim.GetBool("Falling"))
        {
            anim.SetBool("Falling", false);
        }
    }

    private void Move()
    {
        if (facingRight)
        {
            if (transform.position.x <= rightCap)
            {
                if (transform.localScale.x == -1)
                {
                    transform.localScale = new Vector3(1, 1);
                }
                if (coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(jumpLength, jumpHeight);
                    anim.SetBool("Jumping", true);
                }
            }
            else
            {
                facingRight = false;

            }


        }
        else
        {
     
            if (transform.position.x >= leftCap)
            {
                if (transform.localScale.x == 1)
                {
                    transform.localScale = new Vector3(-1, 1);
                }
                if (coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(-jumpLength, jumpHeight);
                    anim.SetBool("Jumping", true);
                }
            }
            else
            {
                facingRight = true;

            }

        }
    }


}
