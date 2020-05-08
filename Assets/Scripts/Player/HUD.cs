using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //it allows to user to enable the UI tools
public class HUD : MonoBehaviour
{
    public Sprite[] HeartSprites;//Allows to store multiple sptrites

    public Image HeartUI;
    
    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();    

    }

    void Update()
    {
        HeartUI.sprite = HeartSprites[player.curHealth];    
    }
}
