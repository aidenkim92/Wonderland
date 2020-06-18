using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class LoadBossOpening : MonoBehaviour
{
    public double videoLength;

    public VideoPlayer vp;

    
    // Start is called before the first frame update
    void Start()
    {
        vp = gameObject.GetComponent<VideoPlayer>();
        vp.Play();
        Player.instance.currentMapName = "BigBoss";
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(vp.time);
        
        if (vp.time >= videoLength)
        {
            
            SceneManager.LoadScene(10);

        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene(10);

        }

    }
}
