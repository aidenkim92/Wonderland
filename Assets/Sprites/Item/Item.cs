using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ScriptableObject is a data container that you can use to save large amounts of data, independent of class instances.
 */

[CreateAssetMenu(menuName = "Item", fileName = "New Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public string itemDes;

    public Sprite itemSprite;
    public int itemPrice;
}
