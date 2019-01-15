using NSubstitute;
using NUnit.Framework;
using Player;

public class PlayerHealthTest
{

    [Test]
    public void TakeDamageTests()
    {
        int startingHealth = 100;
        int damage = 10;

        var mockHealthDelegate = Substitute.For<HealthControllerDelegate>();
        HealthController healthController = new HealthController(startingHealth, mockHealthDelegate);

        healthController.SubstractDamage(damage);

        int expectedHealth = startingHealth - damage;
        Assert.That(healthController.Health, Is.EqualTo(expectedHealth));

        mockHealthDelegate.Received().HealthDidChange(expectedHealth);
        mockHealthDelegate.DidNotReceive().AliveStatusDidChange(HealthController.AliveStatus.dead);
        mockHealthDelegate.Received().AliveStatusDidChange(HealthController.AliveStatus.alive);
    }

    [Test]
    public void DeathTests()
    {
        int startingHealth = 100;
        int damage = 100;

        var mockHealthDelegate = Substitute.For<HealthControllerDelegate>();
        HealthController healthController = new HealthController(startingHealth, mockHealthDelegate);

        healthController.SubstractDamage(damage);

        int expectedHealth = startingHealth - damage;
        Assert.That(healthController.Health, Is.EqualTo(expectedHealth));

        mockHealthDelegate.Received().HealthDidChange(expectedHealth);
        mockHealthDelegate.Received().AliveStatusDidChange(HealthController.AliveStatus.dead);
        mockHealthDelegate.DidNotReceive().AliveStatusDidChange(HealthController.AliveStatus.alive);
    }
}