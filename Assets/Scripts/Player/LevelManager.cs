using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        StartCoroutine(RespawnCo(null));
    }

    public void RespawnPlayerForBoss(Transform position)
    {
        StartCoroutine(RespawnCo(position));
    }

    //Class Respawns player at checkpoint when they die with max health
    private IEnumerator RespawnCo(Transform position)
    {
        if (Player.instance.currentMapName != "BigBoss")
        {
            Player.instance.gameObject.SetActive(false);
            yield return new WaitForSeconds(waitToRespawn);

            AudioManager.instance.PlaySFX(4);
            Player.instance.gameObject.SetActive(true);

            Player.instance.transform.position = CheckpointController.instance.spawnPoint;

            Player.instance.curHealth = Player.instance.maxHealth;

            UIManager.instance.ResetPlayer();
        }

        else
        {
            Player.instance.gameObject.SetActive(false);
            yield return new WaitForSeconds(waitToRespawn);

            AudioManager.instance.PlaySFX(4);
            Player.instance.gameObject.SetActive(true);

            Player.instance.transform.position = position.position;

            Player.instance.curHealth = Player.instance.maxHealth;

            UIManager.instance.ResetPlayer();
        }
    }
}
