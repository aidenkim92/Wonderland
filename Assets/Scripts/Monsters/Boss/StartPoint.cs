using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public string startPoint;
    private Player player;
    private CameraController camera;
    void Start()
    {
        player = FindObjectOfType<Player>();
        camera = FindObjectOfType<CameraController>();

        //For startpoint when the user transfer to another loaded Scenes or Maps
        if(startPoint == player.currentMapName)
        {
            camera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, camera.transform.position.z);
            player.transform.position = this.transform.position;
        }
    }

}
