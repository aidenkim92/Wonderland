using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Manages all audio in this game
 * @author Shahil
 * */
public class AudioManager : MonoBehaviour
{
    
    //Variables
    public static AudioManager instance;
    public AudioSource[] soundEffects;
    public AudioSource[] bgm; 


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

    //Purpose of this class is to play and loop background music
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
    //int variable is an object in array which determines which sound effect to play
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
