using UnityEngine;

public class EnemyBulletCollision : MonoBehaviour {

    private GameObject playerGameObject;
    private PlayerScript playerScript;
    private string bulletTag = "Bullet";

    void Start () {
        playerGameObject = GameObject.Find ("Player");
        playerScript = playerGameObject.GetComponent<PlayerScript> ();
    }

    void OnCollisionEnter (Collision collision) {
        if (collision.gameObject.tag == bulletTag) {
            playerScript.player.incrementEnemyKills ();
            Destroy (gameObject);
            Destroy (collision.gameObject);
        }
    }
}
