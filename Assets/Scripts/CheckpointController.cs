using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

/**
 * This Class controls every instance of a checkpoint in game
 * @author Shahil Khan
 * */
public class CheckpointController : MonoBehaviour
{
    //variables
    public static CheckpointController instance; //Singleton instance
    private Checkpoint[] checkpoints; //Array of checkpoints
    //testingForrespawnfrom the bigbossScene
    public Vector3 spawnPoint; //Player respawn point


    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update

    void Start()
    {
        checkpoints = FindObjectsOfType<Checkpoint>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
     * This class deactivates all checkpoints controlled by the controller
     */
    public void DeactivateCheckpoints()
    {
      for(int i = 0; i<checkpoints.Length; i++)
        {
            checkpoints[i].ResetCheckPoint();
        }
    }

    /**
     * This class sets the player spawn point
     * */
    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;

    }
}
