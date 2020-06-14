using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private Player player;
    public Transform parent;

    void Start()
    {
        player = FindObjectOfType<Player>();
        
        

    }
    
     void OnTriggerStay2D(Collider2D col) // When triggered
    {
        
        if (col.CompareTag("Player"))
        {
            player.Damage(1);

            //Start coroutine
            StartCoroutine(player.Knockback(0.02f, 20, player.transform.position));
        }

        
    }
}
