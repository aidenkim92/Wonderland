using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion//Singleton Pattern

    //Using Delegate that informs the user to there might be created items.
    public delegate void OnSlotCountChange(int val); //Definition
    public OnSlotCountChange onSlotCountChange;//Instantiate the Definition

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;

    public List<Item> items = new List<Item>();
    private int slotCnt;
    public int SlotCnt
    {
        get => slotCnt;
        set
        {
            slotCnt = value;
            onSlotCountChange.Invoke(slotCnt);
        }
    }

    void Start()
    {
        SlotCnt = 4;
    }

    public bool AddItem(Item _item)
    {
        if(items.Count < SlotCnt)
        {
            items.Add(_item);
            if(onChangeItem != null)
            onChangeItem.Invoke();//If the item is successfully added then invoke the method
            return true; // if the item is successfully added in the inventory return true;

        }
        return false;
    }

    public void RemoveItem(int _index)
    {
        items.RemoveAt(_index);
        onChangeItem.Invoke();
    }

    //Trigger for the player to the FieldItems
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("FieldItem"))
        {
            FieldItems fieldItems = col.GetComponent<FieldItems>();
            if(AddItem(fieldItems.GetItem()))
            {
                fieldItems.DestroyItem();
            }
        }
    }
}
