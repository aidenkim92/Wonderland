using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * This Class Adds a trigger to the player which is used to damage monsters
 * */
public class AttackTrigger : MonoBehaviour
{
    public static int damage = 20;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player" && collision.tag != "CheckPoint" && collision.tag != "Collectable" && collision.tag != "DevilSlimeFire" && collision.tag != "Door" && collision.tag != "BananaMonsterBullet" &&
             collision.tag != "Pinky")
        {
            Debug.Log(collision.tag);
            //If the trriggered
            if ((collision.isTrigger != true) && collision.CompareTag("Enemy"))
            {
                //then sendThe damage to the Mathod Damage in the monster whose has the Damage mathod
                collision.SendMessageUpwards("Damage", damage);
            }
            else if ((collision.isTrigger == true) && collision.CompareTag("Boss"))
            {
                collision.SendMessageUpwards("Damage", damage);
            }
            else if ((collision.isTrigger == true) && collision.CompareTag("BigBoss"))
            {
                collision.SendMessageUpwards("Damage", damage);
            }

        }
    }
}
