using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Text ItemName_Text;
    public Text itemCount_Text;
    public GameObject selected_Item;

    public void AddItem(Item _item)
    {
        ItemName_Text.text = _item.itemName;
        icon.sprite = _item.itemIcon;
        if(Item.ITemType.Use == _item.itemType)
        {
            if(_item.itemCount > 0)
            {
                itemCount_Text.text = "" + _item.itemCount.ToString();
            }
            else
            {
                itemCount_Text.text = "";
            }
        }
        if(Item.ITemType.Equip == _item.itemType)
        {
            if(_item.itemCount >0)
            {
                itemCount_Text.text = "" + _item.itemCount.ToString();
            }
            else
            {
                itemCount_Text.text = "";
            }
        }
    }

    public void RemoveItem()
    {
        ItemName_Text.text = "";
        itemCount_Text.text = "";
        icon.sprite = null;
    }
}
