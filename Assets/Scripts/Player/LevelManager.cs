using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public float waitToRespawn;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }

    private IEnumerator RespawnCo()
    {
        Player.instance.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitToRespawn);

        AudioManager.instance.PlaySFX(4);
        Player.instance.gameObject.SetActive(true);

        Player.instance.transform.position = CheckpointController.instance.spawnPoint;

        Player.instance.curHealth = Player.instance.maxHealth;
        
        UIManager.instance.ResetPlayer();
        



    }
}
