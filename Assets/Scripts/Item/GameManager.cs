using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Player player;
    private CameraController camera;

    public void LoadStart()
    {
        StartCoroutine(LoadWaitCoroutine());
    }

    IEnumerator LoadWaitCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        player = FindObjectOfType<Player>();
        camera = FindObjectOfType<CameraController>();

        camera.target = GameObject.Find("Player");
        
    }
}
