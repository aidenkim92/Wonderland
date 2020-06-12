using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public Animator transition;
    // Update is called once per frame
    void Start()
    {
        transition.SetTrigger("start");
    }
}
