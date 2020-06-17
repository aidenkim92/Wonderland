using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class PinkyEnding : MonoBehaviour
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
            SceneManager.LoadScene(7);
            
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene(7);
            
        }



    }
}
