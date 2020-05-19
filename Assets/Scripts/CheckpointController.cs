using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public static CheckpointController instance;
    private Checkpoint[] checkpoints;
    public Vector3 spawnPoint;


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

    public void DeactivateCheckpoints()
    {
      for(int i = 0; i<checkpoints.Length; i++)
        {
            checkpoints[i].ResetCheckPoint();
        }
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;

    }
}
