using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadHellEnding : MonoBehaviour
{

    private Player player;
    public Transform point;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x >= point.position.x)
        {
            SceneManager.LoadScene(9);
        }
        
    }
}
