using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Player player;
    private new CameraController camera;
    public static GameManager instance;

    public void LoadStart()
    {
        StartCoroutine(LoadWaitCoroutine());
    }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(this);
            instance = this;
        }
    }

    IEnumerator LoadWaitCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        player = FindObjectOfType<Player>();
        camera = FindObjectOfType<CameraController>();

        camera.target = GameObject.Find("Player");
        
    }
}
