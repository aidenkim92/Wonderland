﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class PinkyOpening : MonoBehaviour
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
        if (vp.time >= videoLength)
        {
            SceneManager.LoadScene(5);
            Player.instance.transform.position = new Vector3(146, -1, 0);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene(5);
            Player.instance.transform.position = new Vector3(146, -1, 0);
        }
    }
}
