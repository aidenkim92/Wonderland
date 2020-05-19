using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField]
    static GameObject[] prefab;


    // Update is called once per frame
    public static void DropItem(Transform monster)
    {

        int probability;

        probability = 3;

        if (probability == 3)
        {
            int getRandPrefab = Random.RandomRange(0, prefab.Length);
            Instantiate(prefab[getRandPrefab], new Vector2(monster.transform.position.x, monster.transform.position.y), Quaternion.identity);
        }


    }
}
