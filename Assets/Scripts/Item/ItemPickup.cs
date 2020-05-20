using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public int itemID;
    public int _count;

    void OnTriggerStay2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {

            Inventory.instance.GetAnItem(itemID, _count);
            Destroy(this.gameObject);
            AudioManager.instance.PlaySFX(7);
        }
    }
}
