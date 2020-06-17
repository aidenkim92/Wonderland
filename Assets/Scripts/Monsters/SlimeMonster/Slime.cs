
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Slime : MonoBehaviour
{
    //Define varaibles
    private Collider2D coll;
    private Rigidbody2D rb;
    private Animator anim;
    public int curHealth = 100;


    [SerializeField] public LayerMask ground;

    //Reference player object
    private Player player;


    [SerializeField] public float leftCap;
    [SerializeField] public float rightCap;

    [SerializeField] public float jumpLength;
    [SerializeField] public float jumpHeight;

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

    //Updating of current reaction 
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

    //Move
    private void Move()
    {
        if (facingRight)
        {
            if (transform.position.x <= rightCap)
            {
                if (transform.localScale.x == -1)
                {
                    transform.localScale = new Vector3(1, 1);
                }
                if (coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(jumpLength, jumpHeight);
                    anim.SetBool("Jumping", true);
                }
            }
            else
            {
                facingRight = false;

            }
        }
        else
        {
            if (transform.position.x >= leftCap)
            {
                if (transform.localScale.x == 1)
                {
                    transform.localScale = new Vector3(-1, 1);
                }
                if (coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(-jumpLength, jumpHeight);
                    anim.SetBool("Jumping", true);
                }
            }
            else
            {
                facingRight = true;

            }

        }
    }

    //Check health
    private void checkHealth()
    {
        //Depends on the monster status it updates player current stats.


        if ((curHealth <=0))
        {
            //Probability that for dropping items.
            int probability;
            probability = Random.Range(0, 5);

            if (probability == 3)
            {
                int getRandPrefab = Random.Range(0, prefab.Length-1);
                Instantiate(prefab[getRandPrefab], new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            }
            AudioManager.instance.PlaySFX(6);
            Destroy(gameObject);
        }
    }

    //Determine player is triggered 
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
        gameObject.GetComponent<Animation>().Play("RedFlash_Player");
    }
}

