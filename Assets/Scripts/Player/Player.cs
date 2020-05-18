﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
//using System.Numerics;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Testing for gain experiences and up the level
    public int character_LV = 1;
    public int currentExp = 0;
    public int maxExp = 100;

    //TEsting for save and load data as a binary file.
    public string currentMapName;
    public string currentSceneName;
    //private SaveNLoad saveNLoad;

    //Floats
    public float maxSpeed = 3f;
    public float speed = 50f;
    public float jumpPower = 150f;

    //For double jumping
    public bool canDoubleJump;
    public bool grounded;


    //Stats
    public int curHealth = 7;
    public int maxHealth = 7;

    //References
    private Rigidbody2D rigid;
    private Animator animator;

    public static Player instance;


    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();

        curHealth = maxHealth;
        //saveNLoad = FindObjectOfType<SaveNLoad>();

    }

    [System.Obsolete]
    void Update()
    {
        /*
         *  if(Input.GetKeyDown(KeyCode.F5))
        {
            saveNLoad.callSave();
        }
        if(Input.GetKeyDown(KeyCode.F9))
        {
            saveNLoad.callLoad();
        }

         */


        animator.SetBool("Grounded",grounded);
        //Getting actual the Player speed in the animator
        animator.SetFloat("Speed", Mathf.Abs(rigid.velocity.x));

        
        //To move left
        if(Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        //To move right
        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        //Prevent getting infinite number for jump
        if(Input.GetButtonDown("Jump"))
        {
            if(grounded)
            {
                rigid.AddForce(Vector2.up * jumpPower * 2);
                canDoubleJump = true;
            }
            else
            {
                if(canDoubleJump)
                {
                    canDoubleJump = false;
                    rigid.velocity = new Vector2(rigid.velocity.x, 0);
                    
                    rigid.AddForce(Vector2.up * jumpPower * 2);
                }
            }
        }

        if(curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        
        if(currentExp > maxExp)
        {
            currentExp = maxExp;
        }
        if(curHealth <= 0)
        {
            Die();
        }
    }

     void FixedUpdate()
    {
        Vector3 easeVelocity = rigid.velocity;
        easeVelocity.y = rigid.velocity.y;//Does not affect on Y axis
        easeVelocity.z = 0.0f; //No Z axis
        easeVelocity.x *= 0.75f;

        //Fake friction / Easing the x speed of the player
        if(grounded)
        {
            rigid.velocity = easeVelocity;
        }

        //Get x axis
        float h = Input.GetAxis("Horizontal");

        //Move the player
        rigid.AddForce((Vector2.right * speed) * h);

        //Limiting Player speed
        if(rigid.velocity.x > maxSpeed)
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        if (rigid.velocity.x < -maxSpeed)
        {
            rigid.velocity = new Vector2(-maxSpeed, rigid.velocity.y);
        }
    }

    //When the player is dead
    void Die()
    {
        //Restart
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }

    //When get damage
    public void Damage(int damage)
    {
        curHealth -= damage;
        //Get the animation RedFlash_Player
        //Do not use the animator that has been already defined.
        //Just use reference with this gameObject.
        gameObject.GetComponent<Animation>().Play("RedFlash_Player");
    }

    public IEnumerator Knockback(float knockDuration, float knockbackPower, Vector3 knockbackDirection)
    {
        float timer = 0;

        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        while (knockDuration > timer)
        {
            timer += Time.deltaTime; //Increase timer

            //To knockback to opposite direction
            rigid.AddForce(new Vector3(knockbackDirection.x * -10, knockbackDirection.y * -knockbackPower, transform.position.z));
        }

        yield return 0;
    }
}
