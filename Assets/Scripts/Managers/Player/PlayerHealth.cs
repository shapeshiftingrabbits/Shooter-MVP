using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
            healthSlider.value = healthController.GetHealth();
        }

        public void TakeDamage(int amount)
        {
            healthController.SubstractDamage(amount);
        }

        void UpdateHealthUI()
        {
            healthSlider.value = healthController.GetHealth();
        }

        public bool IsPlayerDead()
        {
            return healthController.IsDead();
        }

        public void HealthDidChange(int health)
        {
            healthSlider.value = health;
        }

        public void AliveStatusDidChange(HealthController.AliveStatus status)
        {
            switch (status)
            {
                case HealthController.AliveStatus.alive:
                    break;
                case HealthController.AliveStatus.dead:
                    //TODO play dead animation.
                    break;
            }
        }
    }
}

