using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroEnding : MonoBehaviour
{
    public double videoLength;

    public VideoPlayer vp;

    private void start()
    {

        vp = gameObject.GetComponent<VideoPlayer>();
        vp.Play();

    }



    void Update()
    {
        Debug.Log(vp.time);

        if (vp.time >= videoLength)
        {
            //SceneManager.LoadScene(2);
            SceneManager.LoadScene(4);
            
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene(4);
            
        }



    }
}
