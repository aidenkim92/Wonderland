using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * This class controls which background music to play depending on scene name**
 * @Author Shahil*/
public class AudioTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            AudioManager.instance.PlayBGM(0);
        }

        else if(SceneManager.GetActiveScene().name == "Intro_Level_0")
        {
            AudioManager.instance.PlayBGM(3);
        }

        else if (SceneManager.GetActiveScene().name == "Pinky")
        {
            AudioManager.instance.PlayBGM(1);
        }

        else if (SceneManager.GetActiveScene().name == "Hell")
        {
            AudioManager.instance.PlayBGM(2);
        }

        else
        {
            AudioManager.instance.PlayBGM(-1);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
