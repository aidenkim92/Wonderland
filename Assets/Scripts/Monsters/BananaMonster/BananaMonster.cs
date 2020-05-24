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
    private Player player;

    public int curHealth = 100;
    public int maxHealth = 100;

    public GameObject[] prefab;

    public float timeBetweenShots;
    private float shotCounter;
    public GameObject bullet;
    public Transform firePoint;
    public Transform banana;

    public bool itemDropped = false;
    public int probability;

    //Initialization
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();

        StartCoroutine("ChangeMovement");
        player = FindObjectOfType<Player>();
    }

    //Physics engine Updates
    private void FixedUpdate()
    {
        move();
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0)
        {
            shotCounter = timeBetweenShots;

            var newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
            newBullet.transform.localScale = banana.localScale;
        }

    }

    private void Update()
    {
        checkHealth();
    }

    private void checkHealth()
    {
        if (curHealth <= 0)
        {
            if (Player.instance.currentExp == Player.instance.maxExp)
            {
                Player.instance.currentExp = 0;
                Player.instance.character_LV += 1;

            }
            else
            {
                Player.instance.currentExp += 10;
                
            }
            int chance;
            chance = Random.Range(0, 3);
            calculateProbability(chance);
            
            AudioManager.instance.PlaySFX(6);
            Destroy(gameObject);

        }

    }
    public void calculateProbability(int chance)
    {
        itemDropped = false;

        if (probability == 3)
        {
            int getRandPrefab = Random.Range(0, prefab.Length);
            Instantiate(prefab[getRandPrefab], new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            itemDropped = true;
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
            transform.localScale = new Vector3(1, 1, 1);
      
        }
        else if (dist == "Right")
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1, 1, 1);
         
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.Damage(2);
            player.gameObject.GetComponent<Animation>().Play("RedFlash_Player");
            player.Knockback(2, 20, player.transform.transform.position);

        }

    }
    public void Damage(int damage)
    {
        curHealth -= damage;
        gameObject.GetComponent<Animation>().Play("RedFlash_Player");
    }
}
