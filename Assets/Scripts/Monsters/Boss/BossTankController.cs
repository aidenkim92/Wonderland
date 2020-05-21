using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTankController : MonoBehaviour
{
    public enum bossStates { shooting, hurt, moving };
    public bossStates currentState;

    public Transform theBoss;
    public Animator anim;

    [Header("Movement")]
    public float moveSpeed;
    public Transform leftPoint, rightPoint;
    private bool moveRight;

    [Header("Shooting")]
    public GameObject bullet;
    public Transform firePoint;
    public float timeBetweenShots;
    private float shotCounter;

    [Header("Hurt")]
    public float hurtTime;
    public float hurtCounter;

    [Header("Health System")]
    public int health = 100;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        currentState = bossStates.shooting;
        player = FindObjectOfType<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case bossStates.shooting:

                shotCounter -= Time.deltaTime;

                if (shotCounter <= 0)
                {
                    shotCounter = timeBetweenShots;

                    var newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
                    newBullet.transform.localScale = theBoss.localScale;
                }

                break;

            case bossStates.hurt:
                if (hurtCounter > 0)
                {
                    hurtCounter -= Time.deltaTime;

                    if (hurtCounter <= 0)
                    {
                        currentState = bossStates.moving;
                    }
                }

                break;

            case bossStates.moving:

                if (moveRight)
                {
                    theBoss.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

                    if (theBoss.position.x > rightPoint.position.x)
                    {

                        theBoss.localScale = new Vector3(1f, 1f, 1f);
                        moveRight = false;

                        EndMovement();
                    }
                }

                else
                {
                    theBoss.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

                    if (theBoss.position.x < leftPoint.position.x)
                    {
                        theBoss.localScale = new Vector3(-1f, 1f, 1f);
                        moveRight = true;
                        EndMovement();
                    }
                }

                break;
        }
    }

       





    public void Damage(int damage)
    {
        anim.SetTrigger("Hit");
        gameObject.GetComponent<Animation>().Play("RedFlash_Player");
        health -= damage;
        currentState = bossStates.hurt;
        hurtCounter = hurtTime;
        
        

        if(health <= 0)
        {
            Destroy(gameObject);
            AudioManager.instance.PlaySFX(8);
        }
            
    }

    private void EndMovement()
    {
        currentState = bossStates.shooting;
        shotCounter = timeBetweenShots;

        anim.SetTrigger("StopMoving");
    }

}
