using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    //life time for the effect motion duration
    [SerializeField] private float lifeTimer;

    //For explosion effect
    private void Start()
    {
        Destroy(gameObject, lifeTimer);
    }
}
