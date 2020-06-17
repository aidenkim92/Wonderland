using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * This Class manages the current Scenes when it pauses and unpauses*
 * @Author Shahil/*/
public class SceneManaging : MonoBehaviour
{

    public PauseMenu menu;
    public SaveNLoad sl;
    public GameObject[] objectActivate;

    public void nextScene()
    {

        this.objectActivated();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Player.instance.transform.position = new Vector3(142, 10, 0);


    }

    public void mainMenu()
    {
        menu.Resume();
        SceneManager.LoadScene(0);


    }

    public void objectActivated()
    {
        for(int i = 0; i< objectActivate.Length; i++)
        {
            objectActivate[i].SetActive(true);
        }
    }

    public void quitGame()
    {
        if(SceneManager.GetActiveScene().buildIndex != 0) {
            menu.Resume();
        }
        
        Application.Quit();
    }

    public void save()
    {
        menu.Resume();
        sl.callSave();
    }

    public void load()
    {

        this.objectActivated();
        sl.callLoad();
        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            menu.Resume();
        }
       



    }

    
}
