using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class SlimeMonster : MonoBehaviour
{
    Rigidbody2D rigid;
    int nextMove;
    Animator animator;
    SpriteRenderer spriteRenderer;
    CapsuleCollider2D capsuleCollider;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Invoke("Think", 2);
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    //Automatically, executed by itself per second 50~60times
    //Physics bases stuffs in the FixedUpdate()
    private void FixedUpdate()
    {
        //Move
        rigid.velocity = new Vector2(nextMove * -1, rigid.velocity.y);
        
        //Detect of the platform
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove * -1 * 0.5f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));

        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("PlatForm"));

        //Detect the monster is almost in front of the collased part from the ground
        if (rayHit.collider == null)
        {
            Debug.Log("Oh tehre is wall!!");
            Turn();
        }
       
    }

    //Recursive Function
    private void Think()
    {
        //Sets next active
        nextMove = Random.Range(-1, 2);

        //Sprite animation
        animator.SetInteger("WalkSpeed", nextMove);
        
        //Flip sprite
        if (nextMove != 0)
        {
            spriteRenderer.flipX = nextMove == 1;
            
        }
     

        //Recursive functionality
        float nextThinkTime = Random.Range(2f, 5f);
        Invoke("Think", nextThinkTime);

    }

    //Turn
    private void Turn()
    {
        nextMove *= -1;
        spriteRenderer.flipX = nextMove == 1;
        CancelInvoke();
        Invoke("Think", 2);
    }

}
