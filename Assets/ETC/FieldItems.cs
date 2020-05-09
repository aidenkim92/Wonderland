using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItems : MonoBehaviour
{
    public Item item;
    public SpriteRenderer image;

    //To set the item
    public void SetItem(Item _item)
    {
        item.itemName = _item.itemName;
        item.itemImage = _item.itemImage;
        item.itemType = _item.itemType;
        item.efts = _item.efts;
        image.sprite = item.itemImage;
    }

    //To get the item
    public Item GetItem()
    {
        return item;
    }

    //To destroy the item
    public void DestroyItem()
    {
        Destroy(gameObject);
    }
}
