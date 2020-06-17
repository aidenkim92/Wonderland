using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Reference for transfering map
    public string currentMapName;
    
    //Movement
    public float maxSpeed = 3f;
    public float speed = 50f;
    public float jumpPower = 150f;
    private bool m_facingRight;

    //For double jumping
    public bool canDoubleJump;
    public bool grounded;

    //Coins
    public int coins = 0;
    public Text coinText;

    //Stats
    public int curHealth = 0;
    public int maxHealth = 7;
    public bool isDead;

    //References
    private Rigidbody2D rigid;
    private Animator animator;

    public static Player instance;
   
    private void Awake()
    {
        if (instance == null)
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
        m_facingRight = true;
        isDead = false;
        TimerController.instance.BeginTimer();
    }

    void Update()
    {
        //SetBool for the ground animation
        animator.SetBool("Grounded", grounded);
        //Getting actual the Player speed in the animator
        animator.SetFloat("Speed", Mathf.Abs(rigid.velocity.x));
        coinText.text = coins.ToString();

        //To move left but facing right
        if (Input.GetAxis("Horizontal") < 0 && m_facingRight)
        {
            Flip();
            //transform.localScale = new Vector3(-1, 1, 1);
        }
        //To move right but facing left
        else if (Input.GetAxis("Horizontal") > 0 && !m_facingRight)
        {
            Flip();
            //transform.localScale = new Vector3(1, 1, 1);
        }

        //Prevent getting infinite number for jump
        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                canDoubleJump = true;
            }
            else
            {
                if (canDoubleJump)
                {
                    canDoubleJump = false;
                    rigid.velocity = new Vector2(rigid.velocity.x, 0);
                    rigid.AddForce(Vector2.up * (jumpPower / 2), ForceMode2D.Impulse);
                }

            }
            AudioManager.instance.PlaySFX(1);
        }

        //check
        if (curHealth <= 0)
        {

            isDead = true;
            AudioManager.instance.PlaySFX(2);
            if (Player.instance.currentMapName != "BigBoss")
            {
                SceneManager.LoadScene(2);
                LevelManager.instance.RespawnPlayer();
            }
            else if (Player.instance.currentMapName == "BigBoss")
            {
                //Testing for Respawn
                currentMapName = "";
                SceneManager.LoadScene(2);
                Player.instance.gameObject.SetActive(false);
                AudioManager.instance.PlaySFX(4);
                Player.instance.gameObject.SetActive(true);
                Player.instance.transform.position = CheckpointController.instance.spawnPoint;
                Player.instance.curHealth = Player.instance.maxHealth;

                UIManager.instance.ResetPlayer();
            }        

        }
        isDead = false;
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
        if (grounded)
        {
            rigid.velocity = easeVelocity;
        }

        //Move the player
        rigid.AddForce((Vector2.right * speed) * h);

        //Limiting Player speed
        if (rigid.velocity.x > maxSpeed)
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        if (rigid.velocity.x < -maxSpeed)
        {
            rigid.velocity = new Vector2(-maxSpeed, rigid.velocity.y);
        }

        /*
         *   if (curHealth <= 0)
        {
            isDead = true;
            if(Player.instance.currentMapName != "BigBoss")
            {
                AudioManager.instance.PlaySFX(2);
                LevelManager.instance.RespawnPlayer();
            }
            else if(Player.instance.currentMapName == "BigBoss")
            {
                //Testing for Respawn
                currentMapName = "";
                //SceneManager.LoadScene(2);
            }
            isDead = false;
           
        }
         */


    }

    //Moving Platform
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag  == ("MovingPlatForm"))
        {
            this.transform.parent = other.transform;
            Debug.Log("MOVING");
        }

        if(other.gameObject.tag == "Bird")
        {
            //Destroy(other.gameObject);
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

        }
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Collectable")
        {
            AudioManager.instance.PlaySFX(7);
            Destroy(collision.gameObject);
            coins++;
            
        }
    }


    //When get damage
    public void Damage(int damage)
    {

        curHealth -= damage;
        //Get the animation RedFlash_Player
        //Do not use the animator that has been already defined.
        //Just use reference with this gameObject.
        if(curHealth > 0)
        {
            gameObject.GetComponent<Animation>().Play("RedFlash_Player");
        }
    }

    //For knockback reaction
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

    public void Flip() {
        m_facingRight = !m_facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
