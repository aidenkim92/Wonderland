using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


namespace Tests
{
    public class TestItemDrop{

        [Test]
        public void CheckItemDropAtProbabilityFailed()
        {

            GameObject b = InstantiateFromResource("BananaMonster");
            BananaMonster banana = b.GetComponent<BananaMonster>();
            banana.calculateProbability(1); // item doesnt drop from anything other than 3
            Assert.AreEqual(banana.itemDropped, false);
        }

        [Test]
        public void CheckItemDropAtProbability()
        {
            GameObject b = InstantiateFromResource("BananaMonster");
            BananaMonster banana = b.GetComponent<BananaMonster>();
            banana.probability = 3;  // item drops at 3
            banana.calculateProbability(banana.probability);
            

            Assert.AreEqual(banana.itemDropped, true);
        }

        public static GameObject InstantiateFromResource(string _PrfName)
        {
            return GameObject.Instantiate(Resources.Load<GameObject>(_PrfName));
        }


    }


}
