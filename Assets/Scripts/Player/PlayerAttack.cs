using System.Collections;
using System.Collections.Generic;
//using TMPro;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool attacking = false;
    private float attackTimer = 0.0f;
    private float attackCoolDown = 0.3f;

    public Collider2D attackTrigger;

    private Animator animator;

    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    void Update()
    {   
        //When the key "f" is pressed and not attacking the moment
        if(Input.GetKeyDown("f") && !attacking)
        {
            AudioManager.instance.PlaySFX(0);
            attacking = true;
            attackTimer = attackCoolDown;

            attackTrigger.enabled = true;
            
        }

        //If the attacking is true
        if(attacking)
        {
            
            //If the attack timer is bigger than 0
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime; //Then reduce down the time that has been passed
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }

        animator.SetBool("Attacking", attacking);
    }
}
