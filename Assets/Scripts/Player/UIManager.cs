using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Define variaables that for UI components
    public Slider expBar;
    public Text expText;
    public Text levelText;
    public Slider healthBar;
    public Text HPText;
    public Player player;

    public static UIManager instance;

    private static bool UIExists;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if(!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        ResetPlayer();
    }

    //UI features that need to be updating depends on the main character stats.
   public void ResetPlayer()
    {
        healthBar.maxValue = player.maxHealth;
        healthBar.value = player.curHealth;
       
        if(player.curHealth <= 0 )
        {
            HPText.text = "HP: " + 0 + "/" + player.maxHealth;
        }
        else
        {
            HPText.text = "HP: " + player.curHealth + "/" + player.maxHealth;
        }
        expBar.maxValue = player.maxExp;
        expBar.value = player.currentExp;
        
        expText.text = "Exp: " + player.currentExp + "/" + player.maxExp;

        levelText.text = "Level: " + player.character_LV;

    }
}
