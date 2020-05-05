using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootShot : MonoBehaviour
{
    public GameObject bullet;
    public double shootTime = 1;
    public Transform shootLocation;

    double nextShootTime;

    void Start()
    {
        nextShootTime = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (nextShootTime % 10 == 5)
        {
            Instantiate(bullet, shootLocation.position, Quaternion.identity);
        }
        nextShootTime = nextShootTime+ 0.25;

    }

}
