using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public static bool shopOpen = false;
    // Update is called once per frame
    public GameObject shop;
    public static Shop instance;
    public Text increaseDmgText;
    public Text increaseHealthText;
    private Player player;
    private AttackTrigger at;
    private int increaseDmgPrice = 5;
    private int increaseHealthPrice = 5;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (shopOpen)
            {
                Open();
            }
            else
            {
                Close();
            }
        }

    }

    public void Open()
    {
        increaseHealthText.text = increaseHealthPrice.ToString();
        increaseDmgText.text = increaseDmgPrice.ToString();

        shop.SetActive(false);
        Time.timeScale = 1f;
        shopOpen = false;

    }

    public void Close()
    {
        shop.SetActive(true);
        Time.timeScale = 0f;
        shopOpen = true;

    }

    public void increaseDamage()
    {
        player = FindObjectOfType<Player>();
        if (player.coins >= increaseDmgPrice)
        {
            AttackTrigger.damage += 10;
            player.coins -= increaseDmgPrice;
            increaseDmgPrice += 10;
            
            increaseDmgText.text = increaseDmgPrice.ToString(); 

        }
        Close();
    }

    public void increaseHealth()
    {
        player = FindObjectOfType<Player>();
        if (player.coins >= increaseHealthPrice)
        {
            player.curHealth += 20;
            player.maxHealth += 20;
            player.coins -= increaseHealthPrice;
            increaseHealthPrice += 10;
            
            increaseHealthText.text = increaseHealthPrice.ToString();

        }
        Close();

    }

    public void CheckOnButtonClick()
    {
        if (shopOpen)
        {
            Open();
        }
        else
        {
            Close();
        }
    }
}
