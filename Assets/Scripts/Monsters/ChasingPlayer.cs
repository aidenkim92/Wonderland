using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChasingPlayer : MonoBehaviour
{
    public float moveSpeed;
    public Transform cutSceneTrigger;
    public Checkpoint c;

    //Points for pinky reset
    public GameObject forendPoint;
    public GameObject forstartPoint;
    // Start is called before the first frame update
    void Start()
    {

        AudioManager.instance.PlaySFX(9);

    }

    // Update is called once per frame
    void Update()
    {
        nextScene();

        transform.position = Vector3.MoveTowards(transform.position, forendPoint.transform.position, moveSpeed * Time.deltaTime);

        if(transform.position == forendPoint.transform.position)
        {
            transform.position = forstartPoint.transform.position;
            AudioManager.instance.PlaySFX(9);
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
       if(col.CompareTag("Player") || (Player.instance.transform.position.x == transform.position.x))
        {
            Player.instance.Damage(100);

        }
    }

    public void nextScene()
    {
        if(Player.instance.transform.position.x >= cutSceneTrigger.position.x)
        {
            SceneManager.LoadScene(6);
        }
        
    }
}


