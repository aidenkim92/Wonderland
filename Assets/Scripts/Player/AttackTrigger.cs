using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public int damage = 20;
    void OnTriggerEnter2D(Collider2D col)
    {
        //If the trriggered
        if((col.isTrigger != true) && col.CompareTag("Enemy"))
        {
            //then sendThe damage to the Mathod Damage in the monster whose has the Damage mathod
            col.SendMessageUpwards("Damage", damage);
        }
    }
}
