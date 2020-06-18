using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class LoadBossEnding : MonoBehaviour
{
    public double videoLength;

    public VideoPlayer vp;


    // Start is called before the first frame update
    void Start()
    {
        vp = gameObject.GetComponent<VideoPlayer>();
        vp.Play();
    }

    // Update is called once per frame
    void Update()
    {

        if (vp.time >= videoLength)
        {
            Player.instance.currentMapName = "EndingCredit";
            SceneManager.LoadScene(13);
        }
    }
}
