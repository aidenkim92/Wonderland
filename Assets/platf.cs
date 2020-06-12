using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class platf : MonoBehaviour
{


    public double time = 0d;
    public double currentTime;
    public VideoPlayer vp;

    private void start()
    {
       
        vp = gameObject.GetComponent<VideoPlayer>();
        vp.Play();
        
        
       
        
        
    }



    void Update()
    {
        //Debug.Log(vp.time);

        if(vp.time >= 32d)
        {
            //SceneManager.LoadScene(2);
            SceneManager.LoadScene(2);
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene(2);
            Player.instance.transform.position = new Vector3(142, 10, 0);
        }

       
       
    }
}
