using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChasingPlayer : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed;
    public Transform pinky;
    public int currentPoint;
    private Player player;
    private Vector3 originalPos;
    public Transform cutSceneTrigger;
    public Checkpoint c;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        originalPos = pinky.position;
        AudioManager.instance.PlaySFX(8);

    }

    // Update is called once per frame
    void Update()
    {
        pinky.position = Vector3.MoveTowards(pinky.position, points[currentPoint].position, moveSpeed * Time.deltaTime);
        nextScene();

        if(player.curHealth <=0)
        {
            pinky.position = originalPos;
           
        }

        if(pinky.position.x >= 150)
        {
            //moveSpeed =3;
        }

        if(Math.Abs(pinky.position.x - player.transform.position.x)<= 50)
        {
            AudioManager.instance.PlaySFX(8);
        }

        if(c.transform.position.x >= player.transform.position.x)
        {
            pinky.position = originalPos;

        }

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player") && Math.Abs(pinky.transform.position.x - player.transform.position.x) <=10)
        {
            player.Damage(player.curHealth);
            
            pinky.position = originalPos;
            moveSpeed = 3 ;

            Debug.Log("Killed Player");
        }
    }

    public void nextScene()
    {
        if(player.transform.position.x >= cutSceneTrigger.position.x)
        {
            SceneManager.LoadScene(6);
        }
        
    }
}


