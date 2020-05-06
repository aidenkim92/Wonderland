using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMonsterAttackCone : MonoBehaviour
{
    public TurretMonster turretMonster;

    public bool isLeft = false;

    private void Awake()
    {
        turretMonster = gameObject.GetComponentInParent<TurretMonster>();    
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            if(isLeft)
            {
                turretMonster.Attack(false);
            } 
            else if(!isLeft)
            {
                turretMonster.Attack(true);
            }
        }
    }
}
