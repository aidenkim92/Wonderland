using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class represents a checkpoint in game
 * @author Shahil Khan
 * */
public class Checkpoint : MonoBehaviour
{
    //variables
    public SpriteRenderer theSR; // The SpriteRenderer in Game Controls what sprite is shown
    public Sprite cpOn, cpOff; //The sprite to be shown
    public bool isChecked; //Whether player has turned checkpoint on or not
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
     * Checks if player has walked past the chekpoint. 
     * Deactivates previous checkpoints
     * Turns current checkpoint on and sets player position 
     * 
     * @param other is the collider object i.e. player
     * */
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

    /*
     * Resets all checkpoints
     * */
    public void ResetCheckPoint()
    {
        theSR.sprite = cpOff;
        isChecked = false;
    }


    
}
