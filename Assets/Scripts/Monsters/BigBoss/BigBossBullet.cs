﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBossBullet : MonoBehaviour
{
    public int damage;
    public bool isRotate;

    void Update()
    {
        if(isRotate)
        {
            transform.Rotate(Vector3.forward * 10);
        }
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BorderBullet" || collision.gameObject.tag == "Border")
        {
            gameObject.SetActive(false);
        }
    }
}
