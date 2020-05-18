using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ScriptableObject is a data container that you can use to save large amounts of data, independent of class instances.
 */

[System.Serializable]
public class Item 
{
    public int itemID;
    public string itemName;
    public string itemDescription;
    public int itemCount;
    public Sprite itemIcon;
    public ITemType itemType;
    public enum ITemType
    {
        Use,
        Equip,
        ETC
    }
    public Item(int _itemID,string _itemName,string _itemDes,ITemType _itemType,int _itemCount = 1)
    {
        itemID = _itemID;
        itemName = _itemName;
        itemDescription = _itemDes;
        itemType = _itemType;
        itemCount = _itemCount;
        itemIcon = Resources.Load("ItemIcon/" + _itemID.ToString(), typeof(Sprite)) as Sprite;
    }
}
