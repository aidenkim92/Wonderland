using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDownSound : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip buttonDownSound;

    public AudioSource audioSrc;
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayDownSound()
    {
        audioSrc.PlayOneShot(buttonDownSound);
    }
}
