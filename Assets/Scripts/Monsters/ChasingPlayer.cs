using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChasingPlayer : MonoBehaviour
{
  

    public Transform[] points;
    public float moveSpeed;
    public Transform pinky;
    public int currentPoint;
    private Player player;
    private Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        originalPos = pinky.position;

    }

    // Update is called once per frame
    void Update()
    {
        pinky.position = Vector3.MoveTowards(pinky.position, points[currentPoint].position, moveSpeed * Time.deltaTime);

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            player.Damage(player.curHealth);
            
            pinky.position = originalPos;
        }
    }
}


