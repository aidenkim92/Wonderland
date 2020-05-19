using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestCheckPoint
    {
        // A Test behaves as an ordinary method
        [Test]
        public void CheckPointOffTest()
        {
            var c = new Checkpoint();

            Assert.AreEqual(c.isChecked, false); 
        }

        [Test]
        public void CheckPointOnTest()
        {
            var c = new Checkpoint();
            var player = new Player();

            //Debug.Log(player.grounded);

            //Collider2D collider = player.GetComponent("Capsule Collider 2D") as Collider2D;

           //c.OnTriggerEnter2D(collider);

            Assert.AreEqual(c.isChecked, false);
        }

        
      
    }
}
