using System.Collections;
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
        //Debug.Log(vp.time);

        if (vp.time >= videoLength)
        {
            //SceneManager.LoadScene(2);
            SceneManager.LoadScene(5);
            Player.instance.transform.position = new Vector3(130, 26, 0);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene(5);
            Player.instance.transform.position = new Vector3(130, 26, 0);
        }



    }
}
