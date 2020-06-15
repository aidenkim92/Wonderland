using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRocks : MonoBehaviour
{

    public Rock[] rockguys;
    // Start is called before the first frame update
    void Start()
    {    
    }

    // Update is called once per frame
    void Update()
    { 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
         
            for(int i = 0; i <rockguys.Length; i++)
            {
                rockguys[i].resetPosition();
            }

        }


    }
}
