using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BigBoss : MonoBehaviour
{
    //Variables for the big boss status.
    public int health;
    public int maxHealth;
    public float speed;
    public string BossName;

    //For bullet prefab that is used for attack
    public GameObject bulletObjA;
    public GameObject bulletObjB;
    public GameObject bulletObjC;
    public GameObject bulletSpecial;

    //Reference animator
    Animator anim;

    //For pattern variables for  attack
    public int patternIndex;
    public int curPatternCount;
    public int[] maxPatternCount;

    //when the object is enable
    void OnEnable()
     {
        if(BossName == "BB")
        {
            maxHealth = 3000;
            health = 3000;
            UIManager.instance.bigBossHealthBar.value = health;
            UIManager.instance.bigBossHealthBar.maxValue = maxHealth;
            Invoke("Stop", 2);
        }
     }

    //Stop when the amount of bullets are shooted
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

    //Attack logic method for the several different attack
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

    //Fire forward to the player with the number of bullets
    void FireForward()
    {
        //pink + yellow bullet sound
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

    //Fire shot to the player with combined two bullets
    void FireShot()
    {
        //Add sound for purple shot
     
        for(int i  =0; i < 5; i++)
        {
            GameObject bullet = Instantiate(bulletObjC, transform.position, transform.rotation);
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            bullet.transform.position = transform.position;
            AudioManager.instance.PlaySFX(10);

            if (Player.instance.curHealth > 0)
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

    //Fire arc shape
    void FireArc()
    {
        //add sound for arc of bullets
        GameObject bullet = Instantiate(bulletObjB, transform.position, transform.rotation);
        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        AudioManager.instance.PlaySFX(12);
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

    //Fire around which 360degree to the space
    void FireAround()
    {
        //fire round bullets sound
        
        int roundNum = 50;
        for(int i = 0; i < 50; i++)
        {
            GameObject bullet = Instantiate(bulletObjB, transform.position, transform.rotation);
            AudioManager.instance.PlaySFX(12);
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

    //Fire towards method which it shoot towards to the player for special attack
    void FireTowards()
    {

       
        if(Player.instance.curHealth > 0)
        {
            var bl = new List<Transform>();
            for (int i = 0; i < 360; i += 13)
            {
                var temp = Instantiate(bulletSpecial);
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
    //For fire towards method
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

    //Awake method for the initialize
    void Awake()
    {
        if (BossName == "BB")
        {
            anim = GetComponent<Animator>();
        }
    }

    //Updating the frame per second
     void Update()
    {
        if(Player.instance.currentMapName != "BigBoss")
        {
            health = maxHealth;
        }
    }
    //Getting Damage by player
    public void Damage(int damage)
    {
        if(BossName == "BB")
        {
            health -= damage;
            UIManager.instance.bigBossHealthBar.value = health;
            if (health <= 0)
            {
                health = 0;
                UIManager.instance.bigBossHealthBar.value = health;
                Destroy(gameObject);
                return;
            }
            anim.SetTrigger("OnHit");
        }
    }

}
