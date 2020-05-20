using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManaging : MonoBehaviour
{

    public PauseMenu menu;
    public SaveNLoad sl;

    public void nextScene()
    {

        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Player.instance.transform.position = new Vector3(142, 10, 0);


    }

    public void mainMenu()
    {
        menu.Resume();
        SceneManager.LoadScene(0);


    }
    public void quitGame()
    {
        menu.Resume();
        Application.Quit();
    }

    public void save()
    {
        menu.Resume();
        sl.callSave();
    }

    public void load()
    {

        menu.Resume();
        sl.callLoad();
        
        

    }

    
}
