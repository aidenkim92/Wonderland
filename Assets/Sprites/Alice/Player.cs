using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variables
    private Rigidbody2D rb;
    private Animator Anim;
    private Collider2D coll;

    //FSM
    private enum State { Idle, Walking, Jumping };
    private State state = State.Idle;

    //Inspector variables
    [SerializeField] private LayerMask ground;
    [SerializeField] private float JumpForce = 10.0f;
    [SerializeField] private float Speed = 7f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    private void Update()
    {
        Movement();
        AnimationState();
        Anim.SetInteger("State", (int)state);
    }

    private void Movement()
    {
        float hdirection = Input.GetAxis("Horizontal");

        if (hdirection < 0)
        {
            rb.velocity = new Vector2(-Speed, rb.velocity.y);
            transform.localScale = new Vector2(0.1f, 0.1f);

        }
        else if (hdirection > 0)
        {
            rb.velocity = new Vector2(Speed, rb.velocity.y);
            transform.localScale = new Vector2(-0.1f, 0.1f);
        }
        else if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            state = State.Jumping;
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            
        }
    }

    private void AnimationState()
    {
        //Moving
        if (Mathf.Abs(rb.velocity.x) > 0.1f)
        {
            state = State.Walking;
        }
        //Not moving
        else
        {
            state = State.Idle;
        }
    }
}
