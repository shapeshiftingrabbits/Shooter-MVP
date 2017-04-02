using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    public class Player
    {
        private int enemiesKilled = 0;

        public int EnemiesKilled () {
            return enemiesKilled;
        }

        public void incrementEnemyKills () {
            enemiesKilled++;
        }
    }

    public Player player = new Player();
}
