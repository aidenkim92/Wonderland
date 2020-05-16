using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public Item itemData;
    public GameObject pickupEffect;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            //Items number greater than the inventory grid or total items slots that can be holded
            if(GameManager.instance.items.Count < GameManager.instance.slots.Length)
            {
                Instantiate(pickupEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);

                GameManager.instance.AddItem(itemData);
            }
            else
            {
                Debug.Log("You cannot pick up any items now. Your bag is FULL");
            }
            
        }
    }
}
