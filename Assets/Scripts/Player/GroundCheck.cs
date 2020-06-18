using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    //Trigger when the trigger started
    //When the player is on the ground
     void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "PlatForm" || col.gameObject.tag == "MovingPlatform" || col.gameObject.tag == "Bird")
        {
            Player.instance.grounded = true;
        }
    }

    //Make sure the ground is true when the trigger is on
     void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlatForm" || col.gameObject.tag == "MovingPlatform" || col.gameObject.tag == "Bird")
        {
            Player.instance.grounded = true;
        }
    }

    //Trigger when the trigger is exit
    //When the player is in the air
     void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlatForm" || col.gameObject.tag == "MovingPlatform" || col.gameObject.tag == "Bird")
        {
            Player.instance.grounded = true;
        }
    }

   
}
