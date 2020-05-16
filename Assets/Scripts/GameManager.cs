using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isInventoryOpen = false;

    public List<Item> items = new List<Item>();
    public List<int> itemNumbers = new List<int>();
    public GameObject[] slots; // i got 24 slots

    //public Dictionary<Item, int> itemDict = new Dictionary<Item, int>();


    public Item addItem_01;
    public Item removeItem_01;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            AddItem(addItem_01);
        }
        
        if(Input.GetKeyDown(KeyCode.N))
        {
            RemoveItem(removeItem_01);
        }
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        DisplayItems();  
    }

    private void DisplayItems()
    {
        #region
        /*
         * for(int i = 0; i < items.Count; i++)
        {
            //Update slots Item Image
            slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;

            //Update slots Count Text
            slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);
            slots[i].transform.GetChild(1).GetComponent<Text>().text = itemNumbers[i].ToString();

            //Update close/throw button
            slots[i].transform.GetChild(2).gameObject.SetActive(true);
        }
         */

        #endregion

        for (int i = 0; i < slots.Length; i++)
        {
            if(i < items.Count)
            {
                //Update slots Item Image
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;

                //Update slots Count Text
                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = itemNumbers[i].ToString();

                //Update close/throw button
                slots[i].transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                //Update slots Item Image
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;

                //Update slots Count Text
                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = null;

                //Update close/throw button
                slots[i].transform.GetChild(2).gameObject.SetActive(false);
            }
        }
    }

    public void AddItem(Item _item)
    {
        //If  there is one existing item in our bags(list)
        if(!items.Contains(_item))
        {
            items.Add(_item);
            itemNumbers.Add(1);
        }
        else//If there is a new _item in our bag
        {
            Debug.Log("You have already got this one");
            for(int i = 0; i < items.Count; i++)
            {
                if(_item == items[i])
                {
                    itemNumbers[i]++;
                }
            }
        }

        DisplayItems();
    }

    public void RemoveItem(Item _item)
    {
        if(items.Contains(_item))
        {
            for(int i = 0; i < items.Count; i++)
            {
                if(_item == items[i])
                {
                    itemNumbers[i]--;
                    if(itemNumbers[i] == 0)
                    {
                        //this item should be removed
                        items.Remove(_item);
                        itemNumbers.Remove(itemNumbers[i]);
                    }
                }
            }
        }
        else
        {
            Debug.Log("There is no " + _item + " in my bags");
        }
        DisplayItems();
    }
}
