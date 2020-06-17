using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    //Acts as a singleton
    public static TimerController instance;
    public Text timeCounter;

    //System name space (format name)
    private TimeSpan timePlaying;
    private bool timerGoing;

    private float elapsedTime;


    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        timeCounter.text = "Time: 00:00:00";
        timerGoing = false;
    }

    //Begin timer
    public void BeginTimer() {
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    //Pause timer
    public void EndTimer() {
        timerGoing = false;
    }

    //Update timer
    private IEnumerator UpdateTimer() {
        while (timerGoing) {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timeString = "Time: " + timePlaying.ToString("mm':'ss':'ff");
            timeCounter.text = timeString;
            yield return null;
        }
    }
}
