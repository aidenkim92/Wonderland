using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    private void Start()
    {
        Player.instance.transform.position = transform.position;
    }
}
