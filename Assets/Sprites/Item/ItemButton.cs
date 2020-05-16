using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Text;
public class ItemButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int buttonID;
    private Item thisItem;

    public ToolTips tooltips;
    private Vector2 position;
    //Function to get items.
    private Item GetThisItem()
    {
        for(int i = 0; i < GameManager.instance.items.Count;i++)
        {
            if (buttonID == i)
            {
                thisItem = GameManager.instance.items[i];
            }
        }

        return thisItem;
    }
    public void CloseButton()
    {
        GameManager.instance.RemoveItem(GetThisItem());
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        
        GetThisItem();
        if(thisItem != null)
        {
            Debug.Log("Enter" + thisItem.itemName + " Slot");

            tooltips.ShowTooltip();
            tooltips.UpdateTooltip(thisItem.itemDes);
            tooltips.UpdateTooltip(GetDetailText(thisItem));
            //Fix this bug later.
            //RectTransformUtility.ScreenPointToLocalPointInRectangle(GameObject.Find("Canvas").transform as RectTransform, Input.mousePosition, null, out position);
            tooltips.SetPosition(position);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (thisItem != null)
        {
            Debug.Log("Exit" + thisItem.itemName + " Slot");

            tooltips.HideTooltip();
            tooltips.UpdateTooltip("");
        }
    }

    private string GetDetailText(Item _item)
    {
        if(_item == null)
        {
            return "";
        }
        else
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Item: {0}\n\n", _item.itemName);

            sb.AppendFormat("Sell Price: {0}\n\n"+"Description: {1}\n\n", _item.itemPrice, _item.itemDes);
            return sb.ToString();
        }
    }
}
