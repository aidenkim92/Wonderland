using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class LoadBigBoss : MonoBehaviour
{
    // Start is called before the first frame update
    public double videoLength;
    public VideoPlayer vp;
    
    void Start()
    {
        vp = gameObject.GetComponent<VideoPlayer>();
        vp.Play();
        //Player.instance.currentMapName = "BigBoss";


    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(vp.time);

        if (vp.time >= videoLength)
        {

            SceneManager.LoadScene(7);

        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene(7);

        }

    }
}
