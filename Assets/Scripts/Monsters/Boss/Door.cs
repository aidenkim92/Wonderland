﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    //string for saving transfer mapname
    public string transferMapName;

    //Reference
    private Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }
    
    //When the object is triggered
    private void OnTriggerEnter2D(Collider2D col)
    {
        //if it is Player taged
        if (col.CompareTag("Player"))
        {
            //Input is key'e', then enter to the scene depends on transfermapname
            if(Input.GetKeyDown("e"))
            {
                player.currentMapName = "BigBoss";
                SceneManager.LoadScene("BigBoss");
            }
        }
    }
    
    //Stays trigger
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (Input.GetKeyDown("e"))
            {
                player.currentMapName = "BigBoss";
                SceneManager.LoadScene("BigBoss");
            }
        }
    }
   
}

