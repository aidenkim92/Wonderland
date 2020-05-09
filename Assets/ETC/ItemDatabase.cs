using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;

    private void Awake()
    {
        instance = this;
    }

    public List<Item> itemDB = new List<Item>();
    public GameObject fieldItemPrefab;
    public Vector3[] position;

    //create items
    private void Start()
    {
        for(int i = 0; i < 6; i++)
        {
          GameObject go = Instantiate(fieldItemPrefab,position[i], Quaternion.identity);//De factorized one of the created item
            go.GetComponent<FieldItems>().SetItem(itemDB[Random.Range(0, 3)]);//into One of the item  in the Item DB
           
        }
    }
}
