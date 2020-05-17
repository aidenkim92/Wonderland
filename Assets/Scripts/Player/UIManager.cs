using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Text HPText;
    public Player player;

    private static bool UIExists;
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
        healthBar.maxValue = player.maxHealth;
        healthBar.value = player.curHealth;
        HPText.text = "HP: " + player.curHealth + "/" + player.maxHealth;
    }
}
