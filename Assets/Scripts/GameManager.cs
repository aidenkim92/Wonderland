using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int money =0;
    public int lives;

    private void Awake()
    {
        MakeSingleton();
    }


    void MakeSingleton()
    {
        if(instance != null){
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void addMoney()
    {
        money++;
    }
   
}
