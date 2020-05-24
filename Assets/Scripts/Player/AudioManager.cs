using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Manages all audio in this game
 * @author Shahil
 * */
public class AudioManager : MonoBehaviour
{
    

    public static AudioManager instance;

    public AudioSource[] soundEffects;

    public AudioSource bgm, levelEndMusic;



    void Awake()
    {
        instance = this;
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
