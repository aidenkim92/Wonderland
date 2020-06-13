using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

public class BigBoss : MonoBehaviour
{
    public int health;
    public float speed;
    public string BossName;

    public GameObject bulletObjA;
    public GameObject bulletObjB;

    //Testing
    public GameObject bulletObjC;

    Animator anim;

    //Testing
    public int patternIndex;
    public int curPatternCount;
    public int[] maxPatternCount;


     void OnEnable()
    {
        if(BossName == "BB")
        {
            health = 3000;
            Invoke("Stop", 2);
        }
    }

    void Stop()
    {
        if (!gameObject.activeSelf)
        {
            return;
        }
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.zero;

        Invoke("Think", 2);
    }

    void Think()
    {
        //patternIndex = patternIndex == 3 ? 0 : patternIndex + 1;
        patternIndex = patternIndex == 4 ? 0 : patternIndex + 1;
        curPatternCount = 0;

        switch(patternIndex)
        {
            case 0:
                FireForward();
                break;
            case 1:
                FireShot();
                break;
            case 2:
                FireArc();
                break;
            case 3:
                FireAround();
                break;
            case 4:
                FireTowards();
                break;
        }
    }

    void FireForward()
    {
        GameObject bulletA = Instantiate(bulletObjA, transform.position, transform.rotation);
        Rigidbody2D rigidA = bulletA.GetComponent<Rigidbody2D>();
        bulletA.transform.position = transform.position + Vector3.left * 0.3f;

        GameObject bulletB = Instantiate(bulletObjB, transform.position, transform.rotation);
        Rigidbody2D rigidB = bulletB.GetComponent<Rigidbody2D>();
        bulletB.transform.position = transform.position + Vector3.left * 0.3f;

        if(Player.instance.curHealth > 0)
        {
            Vector3 dirVecA = Player.instance.transform.position - (transform.position + Vector3.right * 0.3f);
            Vector3 dirVecB = Player.instance.transform.position - (transform.position + Vector3.right * 0.3f);

            rigidA.AddForce(dirVecA.normalized * 4, ForceMode2D.Impulse);
            rigidB.AddForce(dirVecB.normalized * 4, ForceMode2D.Impulse);
        }

        curPatternCount++;

        if(curPatternCount < maxPatternCount[patternIndex])
        {
            Invoke("FireForward", 3f);
        }
        else
        {
            Invoke("Think", 3);
        }       
    }

    void FireShot()
    {
     
        for(int i  =0; i < 5; i++)
        {
            GameObject bullet = Instantiate(bulletObjB, transform.position, transform.rotation);
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            bullet.transform.position = transform.position;

            if(Player.instance.curHealth > 0)
            {
                Vector2 dirVec = Player.instance.transform.position - transform.position;
                Vector2 randVec = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(0f, 2f));
                dirVec += randVec;
                rigid.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse);

            }

        }

        curPatternCount++;

        if (curPatternCount < maxPatternCount[patternIndex])
        {
            Invoke("FireShot", 2.5f);
        }
        else
        {
            Invoke("Think", 3);
        }
    }

    void FireArc()
    {
        GameObject bullet = Instantiate(bulletObjA, transform.position, transform.rotation);
        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = Quaternion.identity;

        Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI *5* curPatternCount/ maxPatternCount[patternIndex]), -1);
     
        rigid.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);




        curPatternCount++;

        if (curPatternCount < maxPatternCount[patternIndex])
        {
            Invoke("FireArc", 0.15f);
        }
        else
        {
            Invoke("Think", 3);
        }
    }

    void FireAround()
    {
        int roundNum = 50;
        for(int i = 0; i < 50; i++)
        {
            GameObject bullet = Instantiate(bulletObjB, transform.position, transform.rotation);
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = Quaternion.identity;

            Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * 2 * i/ roundNum), Mathf.Sin(Mathf.PI * 2 * i / roundNum));

            rigid.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);
        }



        curPatternCount++;

        if (curPatternCount < maxPatternCount[patternIndex])
        {
            Invoke("FireAround", 0.7f);
        }
        else
        {
            Invoke("Think", 3);
        }
    }

    void FireTowards()
    {
       

        if(Player.instance.curHealth > 0)
        {
            var bl = new List<Transform>();
            for (int i = 0; i < 360; i += 13)
            {
                var temp = Instantiate(bulletObjC);
                Destroy(temp, 2f);
                temp.transform.position = this.transform.position;
                bl.Add(temp.transform);
                temp.transform.rotation = Quaternion.Euler(0, 0, i);

            }
            StartCoroutine(BulletToTarget(bl));
        }

        curPatternCount++;

        if (curPatternCount < maxPatternCount[patternIndex])
        {
            Invoke("FireAround", 0.7f);
        }
        else
        {
            Invoke("Think", 3);
        }
    }
    //For Fire Towards!
    IEnumerator BulletToTarget(List<Transform> bullet)
    {
        yield return new WaitForSeconds(0.5f);

        for(int i = 0; i < bullet.Count; i++)
        {
            var target_dir = Player.instance.transform.position - bullet[i].position;
            var angle = Mathf.Atan2(target_dir.y, target_dir.x) * Mathf.Rad2Deg;
            bullet[i].rotation = Quaternion.Euler(0, 0, angle);
        }
        bullet.Clear();
    }

    void Awake()
    {

        if (BossName == "BB")
        {
            anim = GetComponent<Animator>();
        }
    }


    //Aiden needs to add the animator when it gets damage by the player.
    public void Damage(int damage)
    {
        if(health <= 0)
        {
            return;
        }
        if(BossName == "BB")
        {
            health -= damage;
            anim.SetTrigger("OnHit");
        }
        
    }
}
