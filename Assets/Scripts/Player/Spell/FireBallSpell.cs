using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBallSpell : MonoBehaviour
{
    public Transform firePosition;
    public GameObject projectile;
    private int spellIndex = 0;
    public float cooldownTime;
    private float nextFireTime;
    private bool isCooldown;
    public Image imageCooldown;
    public GameObject spellG;

    // Update is called once per frame
    void Update()
    {
        //Spell Cooldown
        if (Time.time > nextFireTime)
        {
            if (Input.GetKeyDown("g"))
            {
                nextFireTime = Time.time + cooldownTime;
                Shoot(spellIndex);
            }
        }
        //Image Cooldown
        if (isCooldown)
        {
            imageCooldown.fillAmount += 1 / (cooldownTime * Time.deltaTime);
            if (imageCooldown.fillAmount >= 1)
            {
                imageCooldown.fillAmount = 0;
                isCooldown = false;
            }
        }
    }

    //Selecting spell using buttons
    public void setSpell(int Index)
    {
        spellIndex = Index;
    }

    //Shooting the spell function
    void Shoot(int spellIndex)
    {
        isCooldown = true;
        Instantiate(projectile, firePosition.position, firePosition.rotation);
    }
}
