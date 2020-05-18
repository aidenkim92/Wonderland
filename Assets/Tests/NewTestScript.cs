using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class NewTestScript
    {

        [UnityTest]

        public IEnumerator MonsterGetDamaged()
        {
            TestHelper.PrepareTest();

            GameObject monsterGO = TestHelper.InstantiateFromResource("QutieMonster");
            QutieMonster _m = monsterGO.GetComponent<QutieMonster>();

            _m.curHealth = 100;
            _m.Damage(20);
            yield return null;


            Assert.AreEqual(80, _m.curHealth);
        }

    }


    public static class TestHelper
    {
        public static GameObject InstantiateFromResource(string _PrfName)
        {
            return GameObject.Instantiate(Resources.Load<GameObject>(_PrfName));
        }


        public static void CleanUp()
        {
            GameObject[] AllGameObjects = GameObject.FindObjectsOfType<GameObject>();

            foreach (GameObject _g in AllGameObjects)
            {
                if (_g.name == "Code-based tests runner")
                {


                }
                else
                {
                   GameObject.Destroy(_g);

                }

            }
        }

        public static void PrepareTest()
        {
            CleanUp();
            //InstantiateFromResource("Camera");
            //InstantiateFromResource("EventSystem");
            //InstantiateFromResource("Canvas");

        }
    }
}
