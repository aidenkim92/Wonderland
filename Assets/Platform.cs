using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Player player;


    public void OnCollisionEnter2D(Collision2D other)
    {
        player = FindObjectOfType<Player>();
        if (other.gameObject.tag == ("Player"))
        {
            Debug.Log("asdjhasdkjhasjkdh");
            player.transform.parent = this.transform;
        }
    }

    public void OnCollisionStay2D(Collision2D other)
    {
        player = FindObjectOfType<Player>();
        Debug.Log("asdjhasdkjhasjkdh");
        if (other.gameObject.tag == ("Player"))
        {
            player.transform.parent = this.transform;
        }
    }



    public void OnCollisionExit2D(Collision2D other)
    {
        player = FindObjectOfType<Player>();
        if (other.gameObject.tag == ("Player"))
        {
            player.transform.parent = null;
        }
    }
}
