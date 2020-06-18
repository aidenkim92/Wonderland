using System.Collections;
using System.Collections.Generic;
//using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


namespace Tests
{
    public class TestBananaTakingDamage
    {

       // [Test]
        public void BananaTakingDamage()
        {

            GameObject b = InstantiateFromResource("BananaMonster");
            BananaMonster banana = b.GetComponent<BananaMonster>();
            banana.curHealth = 100;
            banana.Damage(50);

         //   Assert.AreEqual(banana.curHealth, 50);
        }

        public static GameObject InstantiateFromResource(string _PrfName)
        {
            return GameObject.Instantiate(Resources.Load<GameObject>(_PrfName));
        }


    }


}
