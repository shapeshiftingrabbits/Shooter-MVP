using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;

namespace UnityTest{
    
    [TestFixture]
    [Category("Player Health Tests")]
        public class PlayerHealthTests {
        
        int startingHealth = 100;
        
        [Test]
        public void TakeDamageTests(){

            int damage = 10;

            var mockHealthDelegate = Substitute.For<HealthControllerDelegate>();
            HealthController healthController = new HealthController(startingHealth, mockHealthDelegate);

            healthController.SubstractDamage(damage);

            int expectedHealth = startingHealth - damage;
            Assert.That(healthController.GetHealth(), Is.EqualTo(expectedHealth));

            mockHealthDelegate.Received().HealthDidChange(expectedHealth);
            mockHealthDelegate.DidNotReceive().AliveStatusDidChange(HealthController.AliveStatus.dead);
            mockHealthDelegate.Received().AliveStatusDidChange(HealthController.AliveStatus.alive);
        }

        [Test]
        public void DeathTests(){

            int damage = 100;

            var mockHealthDelegate = Substitute.For<HealthControllerDelegate>();
            HealthController healthController = new HealthController(startingHealth, mockHealthDelegate);

            healthController.SubstractDamage(damage);

            int expectedHealth = startingHealth - damage;
            Assert.That(healthController.GetHealth(), Is.EqualTo(expectedHealth));

            mockHealthDelegate.Received().HealthDidChange(expectedHealth);
            mockHealthDelegate.Received().AliveStatusDidChange(HealthController.AliveStatus.dead);
            mockHealthDelegate.DidNotReceive().AliveStatusDidChange(HealthController.AliveStatus.alive);
        }
    }

}

