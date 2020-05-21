using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
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

   public void ResetPlayer()
    {
        healthBar.maxValue = player.maxHealth;
        healthBar.value = player.curHealth;
        HPText.text = "HP: " + player.curHealth + "/" + player.maxHealth;

        expBar.maxValue = player.maxExp;
        expBar.value = player.currentExp;
        Debug.Log(expBar.value = player.currentExp);
        expText.text = "Exp: " + player.currentExp + "/" + player.maxExp;

        levelText.text = "Level: " + player.character_LV;

    }
}
