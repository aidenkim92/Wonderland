using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    
    public static Inventory instance;
    private OkOrCancel ooc;
    private DataBaseManager database;
    private InventorySlot[] slots;
    private List<Item> inventoryItemList;
    private List<Item> inventoryTapList;//shown list that taps

    public string[] tabDescription;

    public Transform tf; // parent Object of the slot

    public GameObject go; //active the inventory or deac
    public GameObject[] selectedTabImages;
    public GameObject go_OOC;

    private int selectedItem;
    private int selectedTab;

    private bool activated;
    private bool tabActivated;
    private bool itemActivated;
    private bool stopKeyInput;//Limitation Q&A when consume the consumable items
    private bool preventExec;//Prevent repeating execution

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);


    void Start()
    {
        instance = this;
        inventoryItemList = new List<Item>();
        inventoryTapList = new List<Item>();
        slots = tf.GetComponentsInChildren<InventorySlot>();
        database = FindObjectOfType<DataBaseManager>();
        ooc = FindObjectOfType<OkOrCancel>();

    }

    public List<Item> SaveItem()
    {
        return inventoryItemList;
    }

    public void LoadItem(List<Item> _itemList)
    {
        inventoryItemList = _itemList;
    }
   
    public void GetAnItem(int _itemID,int _count = 1)
    {
        for(int i = 0; i < database.itemList.Count;i++)
        {
            if(_itemID == database.itemList[i].itemID)
            {
                for(int j = 0; j <inventoryItemList.Count;j++)
                {
                    if(inventoryItemList[j].itemID == _itemID)
                    {
                        if(inventoryItemList[j].itemType == Item.ITemType.Use)
                        {
                            inventoryItemList[j].itemCount += _count;
                        }
                        else
                        {
                            inventoryItemList.Add(database.itemList[i]);
                        }
                        return;
                    }
                }
                inventoryItemList.Add(database.itemList[i]);
                inventoryItemList[inventoryItemList.Count - 1].itemCount = _count;
                return;
            }
        }

        Debug.LogError("There is no item in the database");
    }
    public void RemoveSlot()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveItem();
            slots[i].gameObject.SetActive(false);
        }
    } //Default the inventory
    public void ShowTab()
    {
        RemoveSlot();
        SelectedTab();
    }//Activate the tab
    public void SelectedTab()
    {
        StopAllCoroutines();
        Color color = selectedTabImages[selectedTab].GetComponent<Image>().color;
        color.a = 0f;
        for(int i = 0;i < selectedTabImages.Length; i++)
        {
            selectedTabImages[i].GetComponent<Image>().color = color;
        }
        Debug.Log(tabDescription[selectedTab]);
        StartCoroutine(SelectedTabEffectCoroutine());
    }// Only selected item should be flashed
    IEnumerator SelectedTabEffectCoroutine()
    {
        while (itemActivated)
        {
            Color color = slots[0].GetComponent<Image>().color;
            while (color.a < 0.5f)
            {
                color.a += 0.03f;
                selectedTabImages[selectedTab].GetComponent<Image>().color = color;
                yield return waitTime;
            }

            while (color.a > 0f)
            {
                color.a -= 0.03f;
                selectedTabImages[selectedTab].GetComponent<Image>().color = color;
                yield return waitTime;
            }

            yield return new WaitForSeconds(0.3f);
        }
    } // Effect for flashing the colors
  

    public void ShowItem()
    {
        inventoryTapList.Clear();
        RemoveSlot();
        selectedItem = 0;

        switch(selectedTab)
        {
            case 0:
                for(int i = 0; i < inventoryItemList.Count;i++)
                {
                    if(Item.ITemType.Use == inventoryItemList[i].itemType)
                    {
                        inventoryTapList.Add(inventoryItemList[i]);
                    }

                }
                break;
            case 1:
                for (int i = 0; i < inventoryItemList.Count; i++)
                {
                    if (Item.ITemType.Equip == inventoryItemList[i].itemType)
                    {
                        inventoryTapList.Add(inventoryItemList[i]);
                    }

                }
                break;
            case 2:
                for (int i = 0; i < inventoryItemList.Count; i++)
                {
                    if (Item.ITemType.ETC == inventoryItemList[i].itemType)
                    {
                        inventoryTapList.Add(inventoryItemList[i]);
                    }

                }
                break;
        }// Depends on tabs the items will be loaded.

        for(int i = 0; i < inventoryTapList.Count;i++)
        {
            slots[i].gameObject.SetActive(true);
            slots[i].AddItem(inventoryTapList[i]);
        }

        SelectedItem();
    }//Activate the items
    public void SelectedItem()
    {
        StopAllCoroutines();
        if(inventoryTapList.Count > 0)
        {
            Color color = slots[0].selected_Item.GetComponent<Image>().color;
            color.a = 0f;

            for(int i = 0; i < inventoryTapList.Count;i++)
            {
                slots[i].selected_Item.GetComponent<Image>().color = color;
            }
            
            StartCoroutine(SelectedItemEffectCoroutine());
        }
        else
        {
           Debug.Log( "No indentical items");
        }
    }//Only selected item should be flahsed
    IEnumerator SelectedItemEffectCoroutine()
    {
        while(itemActivated)
        {
            Color color = slots[0].GetComponent<Image>().color;
            while(color.a < 0.5f)
            {
                color.a += 0.03f;
                slots[selectedItem].selected_Item.GetComponent<Image>().color = color;
                yield return waitTime;
            }

            while(color.a > 0f)
            {
                color.a -= 0.03f;
                slots[selectedItem].selected_Item.GetComponent<Image>().color = color;
                yield return waitTime;
            }

            yield return new WaitForSeconds(0.3f);
        }
    }// Effect for flash the colors;
    void Update()
    {
        if(!stopKeyInput)
        {
            if(Input.GetKeyDown(KeyCode.I))
            {
                if (PauseMenu.isPaused == false)
                {
                    activated = !activated;

                    if (activated)
                    {
                        go.SetActive(true);
                        selectedTab = 0;
                        tabActivated = true;
                        itemActivated = false;
                        ShowTab();
                    }
                    else
                    {
                        StopAllCoroutines();
                        go.SetActive(false);
                        tabActivated = false;
                        itemActivated = false;
                    }

                }
                    
            }

            if(activated)
            {
                if(tabActivated)
                {
                    if(Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        if(selectedTab < selectedTabImages.Length -1)
                        {
                            selectedTab++;
                        }
                        else
                        {
                            selectedTab = 0;
                        }
                        SelectedTab();
                    }
                    else if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        if (selectedTab > 0)
                        {
                            selectedTab--;
                        }
                        else
                        {
                            selectedTab = selectedTabImages.Length -1;
                        }
                        SelectedTab();
                    }
                    else if(Input.GetKeyDown(KeyCode.Z))
                    {
                        Color color = selectedTabImages[selectedTab].GetComponent<Image>().color;
                        color.a = 0.25f;
                        selectedTabImages[selectedTab].GetComponent<Image>().color = color;
                        itemActivated = true;
                        tabActivated = false;
                        preventExec = true;
                        ShowItem();
                    }
                }
                else if(itemActivated)
                {
                    if(inventoryTapList.Count > 0)
                    {
                        if (Input.GetKeyDown(KeyCode.DownArrow))
                        {
                            if (selectedItem < inventoryTapList.Count - 1)
                            {
                                selectedItem += 1;
                                //Should fix here
                            }
                            else
                            {
                                selectedItem %= 5;
                            }
                            SelectedItem();
                        }
                        else if (Input.GetKeyDown(KeyCode.UpArrow))
                        {
                            if (selectedItem > 1)
                            {
                                selectedItem -= 1;
                            }
                            else
                            {
                                selectedItem = inventoryTapList.Count - 1 - selectedItem;
                            }
                            SelectedItem();
                        }
                        else if (Input.GetKeyDown(KeyCode.RightArrow))
                        {
                            if (selectedItem < inventoryTapList.Count - 1)
                            {
                                selectedItem++;
                            }
                            else
                            {
                                selectedItem = 0;
                            }
                            SelectedItem();
                        }
                        else if (Input.GetKeyDown(KeyCode.LeftArrow))
                        {
                            if (selectedItem > 0)
                            {
                                selectedItem--;
                            }
                            else
                            {
                                selectedItem = inventoryTapList.Count - 1;
                            }
                            SelectedItem();
                        }
                        else if (Input.GetKeyDown(KeyCode.Z) && !preventExec)
                        {
                            if (selectedTab == 0)
                            {
                                stopKeyInput = true;
                                StartCoroutine(OOCCoroutine());
                            }
                            else if (selectedTab == 1)
                            {
                                Debug.Log("Yum");
                            }
                            else
                            {
                                Debug.Log("beep");
                            }
                        }
                    }
                   
                    if (Input.GetKeyDown(KeyCode.X))
                    {
                        StopAllCoroutines();
                        itemActivated = false;
                        tabActivated = true;
                        ShowTab();
                    }
           
                }

                if(Input.GetKeyUp(KeyCode.Z))
                {
                    preventExec = false;
                }
            }
        }
    }

    IEnumerator OOCCoroutine()
    {
       
            go_OOC.SetActive(true);
            ooc.ShowTwoChoice("Use", "Cancel");
            yield return new WaitUntil(() => !ooc.activated);

            if (ooc.GetResult())
            {
                for (int i = 0; i < inventoryItemList.Count; i++)
                {
                    if (inventoryItemList[i].itemID == inventoryTapList[selectedItem].itemID)
                    {
                        database.UseItem(inventoryItemList[i].itemID);
                        if (inventoryItemList[i].itemCount > 1)
                        {
                            inventoryItemList[i].itemCount--;
                        }
                        else
                        {
                            inventoryItemList.RemoveAt(i);
                        }
                        ShowItem();
                        break;
                    }
                }
            }

            stopKeyInput = false;
            go_OOC.SetActive(false);

        
        
        
    }

}
