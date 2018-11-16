using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Enemies
{
    public class EnemyAttack : MonoBehaviour
    {

        private GameObject player;
        private PlayerHealth playerHealth;
        public int attackPoints = 10;
        bool isPlayerInRange = false;
        public float attackTimeThreshold = 1f;
        float incrementTimeUpdate;

        void Awake()
        {
            player = GameObject.FindGameObjectWithTag(Constants.Tag.PLAYER);
            playerHealth = player.GetComponent<PlayerHealth>();
        }


        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject == player)
            {
                isPlayerInRange = true;
            }
        }

        void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject == player)
            {
                isPlayerInRange = false;
            }
        }

        void Update()
        {
            UpdateTimer();
            if (IsTimeToAttack() && isPlayerInRange)
            {
                Attack(player);
                ResetTimer();
            }
        }

        void Attack(GameObject player)
        {
            playerHealth.TakeDamage(attackPoints);
        }

        void UpdateTimer()
        {
            incrementTimeUpdate += Time.deltaTime;
        }

        void ResetTimer()
        {
            incrementTimeUpdate = 0;
        }

        bool IsTimeToAttack()
        {
            return incrementTimeUpdate >= attackTimeThreshold;
        }
    }
}   