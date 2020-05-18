using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{


    public class TestPlayerHealth
    {
        
        private int maxHealth;

        [SetUp]

        public void Setup()
        {
            
            
        }


        [Test]
        public void IsCurrentHealthEqualsMaxHealth()
        {
            var h = new PlayerHealthController();
            Assert.AreEqual(h.currentHealth, h.maxHealth);
        }

        [Test]
        public void RemoveHealthTest()
        {
            var h = new PlayerHealthController();
            int prevh = h.currentHealth;
            h.invincibleCounter = 0;
            h.RemoveHealth();
            Assert.AreNotEqual(prevh, h.currentHealth);

        }

        [Test]

        public void AddHealthTest() { 
        
            var h = new PlayerHealthController();
            Assert.AreEqual(h.currentHealth, h.currentHealth + 1);

        }


       

       









    }
}
