using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevilSlime : MonoBehaviour
{
    //Define varaibles
    private Collider2D coll;
    private Rigidbody2D rb;
    private Animator anim;
    public int curHealth = 100;

    private Animator animator;
    private Vector3 movement;
    private int movementFlag = 0;//0:Idle, 1:Left, 2:Right
    bool isTracing;
    private GameObject traceTarget;


    [SerializeField] public LayerMask ground;

    //Reference player object
    private Player player;


    [SerializeField] public float leftCap;
    [SerializeField] public float rightCap;

    [SerializeField] public float jumpLength;
    [SerializeField] public float jumpHeight;

    public float timeBetweenShots;
    private float shotCounter;
    public GameObject bullet;
    public Transform firePoint;
    public Transform devil_Slime;

    //Reference prefabs for items
    public GameObject[] prefab;

    private bool facingRight = true;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();

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
        checkHealth();
    }

    private void FixedUpdate()
    {
        if (isTracing)
        {
            shotCounter -= Time.deltaTime;

            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;

                var newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
                newBullet.transform.localScale = devil_Slime.localScale;

                Destroy(newBullet, 7);
            }
        }
        
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
            if (transform.position.x <= leftCap)
            {
                dist = "Left";

            }
            else if (transform.position.x <= rightCap)
            {
                dist = "Right";
            }
        }

        if (dist == "Left")
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(-3, 3, 3);

            if (coll.IsTouchingLayers(ground))
            {
                Debug.Log("itasrdklnaslkn");
                rb.velocity = new Vector2(-jumpLength, jumpHeight);
                anim.SetBool("Jumping", true);
            }

                
            

        }
        else if (dist == "Right")
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(3, 3, 3);
            if (coll.IsTouchingLayers(ground))
            {
                rb.velocity = new Vector2(jumpLength, jumpHeight);
                anim.SetBool("Jumping", true);
            }
                
            
        }

    }

    


    //Trace Start
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            traceTarget = other.gameObject;

        }
    }

    //Trace Maintain
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTracing = true;
        }
    }

    //Trace Over
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTracing = false;
        }
    }

    private void checkHealth()
    {
        //Depends on the monster status it updates player current stats.


        if ((curHealth <= 0))
        {

            //Probability that for dropping items.
            int probability;
            probability = Random.Range(0, 5);

            if (probability == 3)
            {
                int getRandPrefab = Random.Range(0, prefab.Length - 1);
                Instantiate(prefab[getRandPrefab], new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            }
            AudioManager.instance.PlaySFX(6);
            Destroy(gameObject);
            SceneManager.LoadScene(3);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            player.Damage(2);
            player.gameObject.GetComponent<Animation>().Play("RedFlash_Player");
            player.Knockback(2, 20, player.transform.transform.position);

        }

    }


    //Getting damage
    public void Damage(int damage)
    {
        curHealth -= damage;
        this.GetComponent<Animation>().Play("RedFlash_Player");
    }
}
