using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Variables for Player UI components
    public Slider healthBar;
    public Text HPText;
    public Player player;
    public static UIManager instance;
    private static bool UIExists;

    //Variables for Big boss UI components
    public Text bigBossHealthText;
    public Slider bigBossHealthBar;
    public GameObject bigbossHealthBargo;

    //Awake method to define instance variable for singleton pattern
    void Awake()
    {
        instance = this;
    }

    //Singletone for UI components
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

    //Update the frame per second
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

        if(Player.instance.currentMapName == "BigBoss")
        {
            bigbossHealthBargo.SetActive(true);
            bigBossHealthText.text = "HP: " + bigBossHealthBar.value;
        }
    }

}
