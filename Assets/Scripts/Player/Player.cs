using System.Collections;
using System.Collections.Generic;
using TMPro;
//using System.Numerics;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Floats
    public float maxSpeed = 3f;
    public float speed = 50f;
    public float jumpPower = 150f;

    //For double jumping
    public bool canDoubleJump;
    public bool grounded;


    //Stats
    public int curHealth;
    public int maxHealth = 100;

    //References
    private Rigidbody2D rigid;
    private Animator animator;

    public static Player instance;
    private void Awake()
    {/*

        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
        */
    }
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();

        curHealth = maxHealth;
    }

    [System.Obsolete]
    void Update()
    {
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


        //Get x axis
        float h = Input.GetAxis("Horizontal");

        //Fake friction / Easing the x speed of the player
        if(grounded)
        {
            rigid.velocity = easeVelocity;
        }

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
