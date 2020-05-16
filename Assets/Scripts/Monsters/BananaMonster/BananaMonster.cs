using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaMonster : MonoBehaviour
{
    public float movePower;
    private Animator animator;
    private Vector3 movement;
    private int movementFlag = 0;//0:Idle, 1:Left, 2:Right
    bool isTracing;
    private GameObject traceTarget;

    //Initialization
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();

        StartCoroutine("ChangeMovement");
    }

    //Physics engine Updates
    private void FixedUpdate()
    {
        move();
    }

    private void move()
    {
        Vector3 moveVelocity = Vector3.zero;
        string dist = "";

        if (isTracing)
        {
            Vector3 playerPos = traceTarget.transform.position;

            if (playerPos.x < transform.position.x)
            {
                dist = "Left";
            }
            else if (playerPos.x > transform.position.x)
            {
                dist = "Right";
            }
        }
        else
        {
            if (movementFlag == 1)
            {
                dist = "Left";

            }
            else if (movementFlag == 2)
            {
                dist = "Right";
            }
        }

        if (dist == "Left")
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(-1, 1, 1);
      
        }
        else if (dist == "Right")
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(1, 1, 1);
         
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }
    //Coroutine
    IEnumerator ChangeMovement()
    {
        //Random Change Movement
        movementFlag = Random.Range(0, 3);

        //Mapping Animation
        if (movementFlag == 0)
        {
            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetBool("isMoving", true);
        }

        //Wait 3 Seconds
        yield return new WaitForSeconds(3f);

        //Restart Logic
        StartCoroutine("ChangeMovement");
    }

    //Trace Start
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            traceTarget = other.gameObject;

            StopCoroutine("ChangeMovement");
        }
    }

    //Trace Maintain
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTracing = true;
            animator.SetBool("isMoving", true);
        }
    }

    //Trace Over
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTracing = true;
            StartCoroutine("ChangeMovement");
        }
    }
}
