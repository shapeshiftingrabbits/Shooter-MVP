using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityTest
{
    public class GameManager : MonoBehaviour
    {

        private SpawnEnemies spawnEnemies;
        public PlayerHealth playerHealth;

        private GameObject player;

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            spawnEnemies = GetComponent<SpawnEnemies>();
            player = GameObject.FindGameObjectWithTag(Constants.Tag.PLAYER);
            playerHealth = player.GetComponent<PlayerHealth>();
        }

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        void Update()
        {
            if (playerHealth.IsPlayerDead())
            {
                spawnEnemies.StopSpawn();
                if (Input.anyKey)
                {
                    RestartLevel();
                }
            }

        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(Constants.Scene.MAIN);
        }
    }
}