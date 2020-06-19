using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

/**
 * Class: Loads the hell scene from the previous scene*/
public class LoadHell : MonoBehaviour
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
            
            SceneManager.LoadScene(8);
            Player.instance.transform.position = new Vector3(-5.28f, 3.39f, 0);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene(8);
            Player.instance.transform.position = new Vector3(-5.28f, 3.39f, 0);
        }

    }
}
