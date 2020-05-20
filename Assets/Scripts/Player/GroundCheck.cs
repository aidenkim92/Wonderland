using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private Player player;

     void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
    }

    //Trigger when the trigger started
    //When the player is on the ground
     void OnTriggerEnter2D(Collider2D col)
    {
        player.grounded = true;
    }

    //Make sure the ground is true when the trigger is on
     void OnTriggerStay2D(Collider2D col)
    {
        player.grounded = true;
    }

    //Trigger when the trigger is exit
    //When the player is in the air
     void OnTriggerExit2D(Collider2D col)
    {
        player.grounded = false;
    }

   
}
