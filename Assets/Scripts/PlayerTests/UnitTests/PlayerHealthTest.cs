using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Player;
using NSubstitute;

public class PlayerHealthTest
{

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator PlayerHealthTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }

    int startingHealth = 100;

    [Test]
    public void TakeDamageTests()
    {

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
    public void DeathTests()
    {

        int damage = 100;

        var mockHealthDelegate =  Substitute.For<HealthControllerDelegate>();
        HealthController healthController = new HealthController(startingHealth, mockHealthDelegate);

        healthController.SubstractDamage(damage);

        int expectedHealth = startingHealth - damage;
        Assert.That(healthController.GetHealth(), Is.EqualTo(expectedHealth));

        mockHealthDelegate.Received().HealthDidChange(expectedHealth);
        mockHealthDelegate.Received().AliveStatusDidChange(HealthController.AliveStatus.dead);
        mockHealthDelegate.DidNotReceive().AliveStatusDidChange(HealthController.AliveStatus.alive);
    }
}