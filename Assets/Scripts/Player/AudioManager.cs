using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Class: Manages all audio in this game
 * An instance of this object is required in all Scenes
 * @author Shahil
 * */
public class AudioManager : MonoBehaviour
{
    
    //Variables
    public static AudioManager instance; //Current instance
    public AudioSource[] soundEffects;
    public AudioSource[] bgm; 

    /**
     * Function: Instantiates an object depending on Singleton Pattern*/
    void Awake()
    {
        
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
         
        }
    }

    /*
     * Function: Determines which background music to play. Stops all current playing music
     * Plays the requested music and ensures it loops
     * If bgm is -1, then no background music will play*/
    public void PlayBGM(int bgmToPlay)
    {
        for(int i =0; i <bgm.Length; i++)
        {
            bgm[i].Stop();
        }

        if (bgmToPlay != -1)
        {
            bgm[bgmToPlay].Play();
            bgm[bgmToPlay].loop = true;
        }

    }
    
    /**
     * Function: Determines which sound effect to play
     * Stopps all currently playing soundeffects.
     * Randomizes pitch
     * Plays the sound*/
    public void PlaySFX(int soundToPlay)
    {
        
        if(PauseMenu.isPaused == false) //If game is not paused
        {
            soundEffects[soundToPlay].Stop();//Stop sound effect 
            soundEffects[soundToPlay].pitch = Random.Range(.9f, 1.1f); //randomize pitch
            soundEffects[soundToPlay].Play(); //play sound effect
        }

    }
}
