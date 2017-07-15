using System;
using System.Collections.Generic;

namespace UnityTest{

    // Helps keep track of the health component associated with an object.
    public class HealthController
    {

        private int health = 0;
        private AliveStatus aliveStatus = AliveStatus.alive;
        private WeakReference healthDelegate = null;

        public enum AliveStatus
        {
            alive, dead
        }

        public HealthController(int startingHealth, HealthControllerDelegate healthDelegate)
        {
            this.health = startingHealth;
            this.healthDelegate = new WeakReference(healthDelegate);
        }

        public int SubstractDamage(int damageAmount)
        {
            health -= damageAmount;
            this.CheckDeathStatus();
            HealthControllerDelegate strongDelegate = healthDelegate.Target as HealthControllerDelegate;
            if (strongDelegate != null)
            {
                strongDelegate.HealthDidChange(health);
            }
            return health;
        }

        public bool IsDead()
        {
            return this.aliveStatus == AliveStatus.dead;
        }

        public void SetHealth(int health)
        {
            this.health = health;
            this.CheckDeathStatus();
        }

        public int GetHealth()
        {
            return this.health;
        }

        private void CheckDeathStatus()
        {
            aliveStatus = (health <= 0) ? AliveStatus.dead : AliveStatus.alive;
            var strongDelegate = healthDelegate.Target as HealthControllerDelegate;
            if (strongDelegate != null)
            {
                strongDelegate.AliveStatusDidChange(aliveStatus);
            }
        }
    }

    public interface HealthControllerDelegate
    {
        void HealthDidChange(int health);
        void AliveStatusDidChange(HealthController.AliveStatus status);
    }
}