using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject inventoryMenu;

    private void Start()
    {
        inventoryMenu.gameObject.SetActive(false);
    }

    private void Update()
    {
        InventoryControl();
    }

    private void InventoryControl()

    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if(GameManager.instance.isInventoryOpen == false)
            {
                Opened();
            }
            else
            {
                inventoryMenu.gameObject.SetActive(false);
                GameManager.instance.isInventoryOpen = false;
            }
        }
       
    }

    private void Opened()
    {
        inventoryMenu.gameObject.SetActive(true);
        GameManager.instance.isInventoryOpen = true;
    }

}
