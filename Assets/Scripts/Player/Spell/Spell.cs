using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public Transform firePosition;
    [SerializeField] private GameObject[] projectile;
    public int spellIndex = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("g")) {
            Shoot(spellIndex);
        }
    }

    //Selecting spell using buttons
    public void setSpell(int Index) {
        spellIndex = Index;
    }

    //Shooting the spell function
    void Shoot(int spellIndex){
        Instantiate(projectile[spellIndex], firePosition.position, firePosition.rotation);
    }
}
