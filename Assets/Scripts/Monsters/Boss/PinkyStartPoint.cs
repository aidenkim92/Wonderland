using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkyStartPoint : MonoBehaviour
{
    private ChasingPlayer pinky;
    void Awake()
    {
        pinky = FindObjectOfType<ChasingPlayer>();
    }

    private void Update()
    {
        //To pinky to reset to the specific point
        if(Player.instance.curHealth <= 0)
        {
            pinky.transform.position = this.transform.position;
        }

        if (pinky.transform.position.x >= Player.instance.transform.position.x)
        {
            pinky.transform.position = this.transform.position;
        }
    }
}
