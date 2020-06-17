using System;
using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
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


    //Timer counter variables
    public Text timeCounter;
    private TimeSpan timePlaying;
    private bool timerGoing;
    private float elapsedTime;


    //Recorded time UI variable
    public GameObject endingCredit;
    public Text timerRecorded;

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

        //Timer starts when the player character is in the game at the first in game scene.
        timeCounter.text = "Time: 00:00:00";
        timerGoing = false;
        BeginTimer();
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

        //When the player is in the big boss scene then
        if(Player.instance.currentMapName == "BigBoss")
        {
            //Set active the Health status bar as active
            bigbossHealthBargo.SetActive(true);
            bigBossHealthText.text = "HP: " + bigBossHealthBar.value;
        }
        else
        {
            bigbossHealthBargo.SetActive(false);
        }

        //When the player is defeat the Big boss monster the ending credit is shown
        if (Player.instance.currentMapName == "BigBoss" && bigBossHealthBar.value == 0)
        {
            endingCredit.SetActive(true);
            timerRecorded.text = "Recorded Time : "+ timeCounter.text;
            EndTimer();
        }
        else
        {
            endingCredit.SetActive(false);
        }

    }

    //Testing for the timer counter
    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    //Pause timer
    public void EndTimer()
    {
        timerGoing = false;
    }

    //Update timer
    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timeString = "Time: " + timePlaying.ToString("mm':'ss':'ff");
            timeCounter.text = timeString;
            yield return null;
        }
    }

}
