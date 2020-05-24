using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * This Class Adds a trigger to the player which is used to damage monsters
 * */
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
        else if ((col.isTrigger == true) && col.CompareTag("Boss")){
            col.SendMessageUpwards("Damage", damage);
        }
    }
}
