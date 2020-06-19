using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * This Class manages the level instance and respawns player at a Checkpoint
 * @author Shahil
 * */
public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public float waitToRespawn;
    
    void Awake()
    {
        instance = this;
    }

    public void RespawnPlayer()
    {
        Invoke("respawn", waitToRespawn);
    }

    private void respawn()
    {
       
        Player.instance.gameObject.SetActive(false);
        AudioManager.instance.PlaySFX(4);
        Player.instance.gameObject.SetActive(true);

        Player.instance.transform.position = CheckpointController.instance.spawnPoint;


        Player.instance.curHealth = Player.instance.maxHealth;

        UIManager.instance.ResetPlayer();
       
    }
}
