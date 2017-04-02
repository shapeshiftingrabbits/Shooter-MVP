using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerEnemyCollision : MonoBehaviour {
    private string enemyTag = "Enemy";

    void OnCollisionEnter (Collision collision) {
        if (collision.gameObject.tag == enemyTag) {
            Die ();
        }
    }

    public void Die () {
        SceneManager.LoadScene ("Main");
    }
}
