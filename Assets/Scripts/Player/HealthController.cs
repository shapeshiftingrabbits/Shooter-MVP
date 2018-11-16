using System;

namespace Player
{

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

        public int Health
        {
            set
            {
                this.health = value;
                this.CheckDeathStatus();
            }

            get { return this.health; }
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
            if (healthDelegate.Target is HealthControllerDelegate strongDelegate)
            {
                strongDelegate.HealthDidChange(health);
            }
            return health;
        }

        public bool IsDead()
        {
            return this.aliveStatus == AliveStatus.dead;
        }

        private void CheckDeathStatus()
        {
            aliveStatus = (health <= 0) ? AliveStatus.dead : AliveStatus.alive;
            if (healthDelegate.Target is HealthControllerDelegate strongDelegate)
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