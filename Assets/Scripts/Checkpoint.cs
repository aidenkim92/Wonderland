using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public SpriteRenderer theSR;
    public Sprite cpOn, cpOff;
    public bool isChecked;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CheckpointController.instance.DeactivateCheckpoints();
            theSR.sprite = cpOn;
            isChecked = true;

            CheckpointController.instance.SetSpawnPoint(transform.position);
        }
    }

    public void ResetCheckPoint()
    {
        theSR.sprite = cpOff;
        isChecked = false;
    }


    
}
