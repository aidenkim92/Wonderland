using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Define variaables that for UI components

    public Slider healthBar;
    public Text HPText;
    public Player player;
    public static UIManager instance;
    private static bool UIExists;


    public Text bigBossHealthText;
    public Slider bigBossHealthBar;
    public GameObject bigbossHealthBargo;
    private GameObject thebb;
    private BigBoss bb;
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

        if(Player.instance.currentMapName == "BigBoss")
        {
            Invoke("checking", 0.5f);
           
        }

    }

   private void checking()
    {
        thebb = GameObject.FindGameObjectWithTag("BigBoss");
        bb = thebb.GetComponent<BigBoss>();
        bigbossHealthBargo.SetActive(true);
        bigBossHealthBar.maxValue = bb.maxHealth;
        bigBossHealthBar.value = bb.health;
        bigBossHealthText.text = "HP: " + bb.health;
    }
}
