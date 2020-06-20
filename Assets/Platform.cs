using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            Debug.Log("asdjhasdkjhasjkdh");
            Player.instance.transform.parent = this.transform;
        }
    }

    public void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log("asdjhasdkjhasjkdh");
        if (other.gameObject.tag == ("Player"))
        {
           Player.instance.transform.parent = this.transform;
        }
    }
}
