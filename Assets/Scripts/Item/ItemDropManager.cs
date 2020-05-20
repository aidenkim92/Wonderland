using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropManager : MonoBehaviour
{

    public  GameObject[] prefab;


    public void dropItem(GameObject other)
    {
        int probability;

        probability = 3;

        if (probability == 3)
        {
            
            int getRandPrefab = Random.RandomRange(0, prefab.Length-1);
            Instantiate(prefab[getRandPrefab], new Vector2(other.transform.position.x, other.transform.position.y), Quaternion.identity);
        }

    }
}
