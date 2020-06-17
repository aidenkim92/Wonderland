using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMonster : MonoBehaviour
{
    //Integers
    public int curHealth = 100;
    public int maxHealth = 100;

    //Floats
    public float distance;
    public float wakeRange;
    public float shootInterval;
    public float bulletSpeed = 10.0f;
    public float bulletTimer;

    //Boolean
    public bool awake = false;
    public bool lookingRight = true;

    //References
    public GameObject bullet;
    //private Transform target;
    public Animator anim;
    public Transform shootPointLeft, shootPointRight;


     void Awake()
    {
        anim = gameObject.GetComponent<Animator>();

    }

     void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        curHealth = maxHealth;
    }

     void Update()
    {
        anim.SetBool("Awake", awake);
        anim.SetBool("LookingRight", lookingRight);
        RangeCheck();

        if(Player.instance.transform.position.x > transform.position.x)
        {
            lookingRight = true;
        }

        if(Player.instance.transform.position.x < transform.position.x)
        {
            lookingRight = false;
        }


        if(curHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

     void RangeCheck()
    {
        distance = Vector3.Distance(transform.position, Player.instance.transform.position);

        if(distance < wakeRange)
        {
            awake = true;

        }

        if(distance > wakeRange)
        {
            awake = false;
        }

    }

     public void Attack(bool attackingRight)
    {
        bulletTimer += Time.deltaTime;

        if(bulletTimer >= shootInterval)
        {
            Vector2 direction = Player.instance.transform.position - transform.position;
            direction.Normalize();

            if(!attackingRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                bulletTimer = 0;
            }
            
            if(attackingRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointRight.transform.position, shootPointRight.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                bulletTimer = 0;
            }
        }
    }

    //If the turret get damaged
    public void Damage(int damage)
    {
        curHealth -= damage;
        gameObject.GetComponent<Animation>().Play("RedFlash_Player");
    }
}
