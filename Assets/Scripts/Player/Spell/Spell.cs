using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public Transform firePosition;
    public GameObject[] projectile;
    public int spellIndex = 0;
    // Update is called once per frame

    // testing for delay of the skill.
    public float maxShotDelay;
    public float curShotDelay;
    void Update()
    {
        if (Input.GetKeyDown("g")) {
            Shoot(spellIndex);
        }
        //Testeing for delay
        Reload();
    }

    //Selecting spell using buttons
    public void setSpell(int Index) {
        spellIndex = Index;
    }


    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }
    //Shooting the spell function
    void Shoot(int spellIndex){

        //Testing for Delay
        if(curShotDelay < maxShotDelay)
        {
            return;
        }
        Instantiate(projectile[spellIndex], firePosition.position, firePosition.rotation);

        //Testing for Delay
        curShotDelay = 0;
    }
}
