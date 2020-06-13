using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    //References
    public static CameraController instance;
    public GameObject target;
    private Vector3 targetPosition;

    //ForBigBoss scene
    private float minX, maxX, minY, maxY;
    //Float
    public float moveSpeed;

    //Singleton
    private void Start()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }

    //Follow the object
    private void Update()
    {
        if(target.gameObject != null && Player.instance.currentMapName == "BigBoss")
        {
            minX = -7.29f;
            maxX = 10.18f;
            minY = 0.47f;
            maxY = 2.31f;

            targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),
                                                Mathf.Clamp(transform.position.y, minY, maxY),
                                                  transform.position.z);
        }
        else if(target.gameObject != null)
        {
            targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        
    }
}
