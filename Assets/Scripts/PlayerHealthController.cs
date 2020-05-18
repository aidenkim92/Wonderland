using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{

    /* Variables */

    //Instance of this class is used in Singleton pattern and allow access to this instance from other classes
    public static PlayerHealthController instance;
    //Health Variables are used to determine current and max health values
    public int currentHealth;
    public int maxHealth = 6;

    //Sprite Renderer variable is used to change the heart sprite showing on screen
    private SpriteRenderer theSR;

    //These variables are used to determine how long the player should be invincible for after taking damage
    public float invincibleLength;
    public float invincibleCounter;

    
    public PlayerHealthController()
    {
        currentHealth = maxHealth;
    }

    public void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        theSR = GetComponent<SpriteRenderer>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        NormalColor();
        
    }

    public void NormalColor()
    {
        if (invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;

            if (invincibleCounter <= 0)
            {
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            }
        }
    }
   

    public void AddHealth()
    {
        

    }

    public void RemoveHealth()
    {
        if (invincibleCounter <= 0)
        {


            currentHealth--;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                gameObject.SetActive(false);
            }
            else
            {
                invincibleCounter = invincibleLength;
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, .5f);
                AliceController.instance.KnockBack();

            }

            UIController.instance.UpdateHealthDisplay();

        }
    }

}

