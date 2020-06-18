using System.Collections;
using System.Collections.Generic;
//using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


namespace Tests
{
    public class ShopIncreasePlayerHealth
    {

        //[Test]
        public void IncreaseHealth()
        {

            GameObject b = InstantiateFromResource("Player");
            Player player = b.GetComponent<Player>();

            player.coins = 5;
            GameObject c = InstantiateFromResource("Player");
            Shop s = c.GetComponent<Shop>();
            s.increaseDamage();
            s.increaseHealth();
        //    Assert.AreEqual(player.maxHealth, 120);
        }

        public static GameObject InstantiateFromResource(string _PrfName)
        {
            return GameObject.Instantiate(Resources.Load<GameObject>(_PrfName));
        }


    }


}