using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseUI;

    private bool paused = false;

    void Start()
    {
        PauseUI.SetActive(false);
    }

    void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }

        //When its paused
        if(paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if(!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Resume()
    {
        paused = false;

    }

    [System.Obsolete]
    public void Restart()
    {
        //string currentSceneName = SceneManager.GetActiveScene().name;
       // SceneManager.LoadScene(currentSceneName);

        Application.LoadLevel(0);
        //SceneManager.LoadScene(2);
        
        //Application.LoadLevel(Application.loadedLevel);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        //Application.LoadLevel(0); //There is no main menu so 0 if there is more scenes then it should be same size of the number of level of the scenes
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Settings()
    {
        
    }
}
