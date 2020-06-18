using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


namespace Tests
{
    public class DevilSlimeTakingDamage
    {

        [Test]
        public void DevilTakingDamage()
        {

            GameObject b = InstantiateFromResource("Devil_Slime");
            DevilSlime devil = b.GetComponent<DevilSlime>();
            devil.curHealth = 100;
            devil.Damage(50);

            Assert.AreEqual(devil.curHealth, 50);
        }

        public static GameObject InstantiateFromResource(string _PrfName)
        {
            return GameObject.Instantiate(Resources.Load<GameObject>(_PrfName));
        }


    }


}
