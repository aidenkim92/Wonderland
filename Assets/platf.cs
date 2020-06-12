using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class platf : MonoBehaviour
{
    

    public double time;
    public double currentTime;
    public VideoPlayer vp;

    private void start()
    {
        time = vp.clip.length;
    }



    void Update()
    {
        currentTime = gameObject.GetComponent<VideoPlayer>().time;
        if (currentTime >= time)
        {
            SceneManager.LoadScene(2);
        }
    }
}
