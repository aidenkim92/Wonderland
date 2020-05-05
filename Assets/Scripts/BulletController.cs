using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    float sporeSpeed;

    Rigidbody2D bulletRB;


    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        bulletRB.velocity = new Vector2(-10, 0);



    }

}
