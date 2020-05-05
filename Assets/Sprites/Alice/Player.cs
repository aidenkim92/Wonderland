using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    public Rigidbody2D rb;
    public Animator Anim;
    public Collider2D coll;

    //FSM
    private enum State { Idle, Walking };
    private State state = State.Idle;

    //Inspector variables
    [SerializeField] private LayerMask ground;
    [SerializeField] private float JumpForce = 10.0f;
    [SerializeField] private float Speed = 7f;

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
            transform.localScale = new Vector2(-1, 1);

        }
        else if (hdirection > 0)
        {
            rb.velocity = new Vector2(Speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }
    }

    private void AnimationState()
    {
        //Moving
        if (Mathf.Abs(rb.velocity.x) > 3f)
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
