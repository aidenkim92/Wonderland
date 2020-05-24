using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseManager : MonoBehaviour
{
    public static DataBaseManager instance;
    private Player player;
    //public GameObject parent;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(this);
            instance = this;
        }
    }
    public string[] var_name;
    public float[] var;
    public string[] switch_name;
    public bool[] switches;

    public List<Item> itemList = new List<Item>();
    public void UseItem(int _itemID)
    {
        switch(_itemID)
        {
            case 1:
                player.curHealth += 1;
                if (player.curHealth > player.maxHealth)
                {
                    player.curHealth = player.maxHealth;
                }
                
                break;

            case 2:
                player.curHealth += 3;
                if (player.curHealth > player.maxHealth)
                {
                    player.curHealth = player.maxHealth;
                }
                break;
        }
    }
    void Start()
    {
        player = FindObjectOfType<Player>();
        itemList.Add(new Item(1, "Small Portion", "HP portion (10)", Item.ITemType.Use));
        itemList.Add(new Item(2, "Large Portion", "HP portion (50)", Item.ITemType.Use));
        itemList.Add(new Item(3, "Ninja ", "Attack with a Ninja", Item.ITemType.Equip));
    }
}
