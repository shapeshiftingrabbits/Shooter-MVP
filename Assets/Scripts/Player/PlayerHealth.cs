using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerHealth : MonoBehaviour, HealthControllerDelegate
    {

        public int startingHealth;
        public Slider healthSlider;

        private HealthController healthController;

        void Awake()
        {
            healthController = new HealthController(startingHealth, this);
            healthSlider.value = healthController.Health;
        }

        public void TakeDamage(int amount)
        {
            healthController.SubstractDamage(amount);
        }

        void UpdateHealthUI()
        {
            healthSlider.value = healthController.Health;
        }

        public bool IsDead()
        {
            return healthController.IsDead();
        }

        #region HealthControllerDelegate
        public void HealthDidChange(int health)
        {
            healthSlider.value = health;
        }

        public void AliveStatusDidChange(HealthController.AliveStatus status)
        {
            //DO NOTHING
        }

        #endregion
    }
}

