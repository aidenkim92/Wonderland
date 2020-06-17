using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class RockSpikes : MonoBehaviour
{
    //Parent reference
    public Transform parent;

    //Trigger on when the colide with this object
    void OnTriggerStay2D(Collider2D col) // When triggered
    {

        if (col.CompareTag("Player"))
        {
            Player.instance.Damage(50);
        }
    }
}
