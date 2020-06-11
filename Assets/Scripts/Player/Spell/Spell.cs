using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spell : MonoBehaviour
{
    public Transform firePosition;
    public GameObject[] projectile;
    public int spellIndex = 0;
    public float cooldownTime;
    public float nextFireTime;
    private bool isCooldown;
    //public Image[] imageCooldown;
    //public GameObject[] spellG;

    private void Start()
    {
        //Sets all spells with the G symbol to be turned off
        /*for (int i = 0; i < spellG.Length; i++) {
            spellG[i].SetActive(false);
        }
        spellG[spellIndex].SetActive(true);*/
    }
    // Update is called once per frame
    void Update()
    {
        //Spell Cooldown
        if(Time.time > nextFireTime) { 
            if (Input.GetKeyDown("g")) {
                nextFireTime = Time.time + cooldownTime;
                Shoot(spellIndex);
            }
        }
        //Image Cooldown
       /* if (isCooldown)
        {
            for (int i = 0; i < imageCooldown.Length; i++)
            {
                if (i != spellIndex)
                {
                    imageCooldown[i].fillAmount = 1;
                }
            }
            imageCooldown[spellIndex].fillAmount += 1 / cooldownTime * Time.deltaTime;
            if (imageCooldown[spellIndex].fillAmount >= 1)
            {
                imageCooldown[spellIndex].fillAmount = 0;
                isCooldown = false;
            }
        }
        else {
            for (int i = 0; i < imageCooldown.Length; i++)
            {
                if (i != spellIndex)
                {
                    imageCooldown[i].fillAmount = 0;
                }
            }
        }*/
    }

    //Selecting spell using buttons
    public void setSpell(int Index) {
        //Makes sure not to change spells while one is in cooldown
       /* if (!isCooldown)
        {
            spellG[spellIndex].SetActive(false);
            spellG[Index].SetActive(true);
            spellIndex = Index;
        }*/
    }

    //Shooting the spell function
    void Shoot(int spellIndex){
        isCooldown = true;
        Instantiate(projectile[spellIndex], firePosition.position, firePosition.rotation);
    }
}
