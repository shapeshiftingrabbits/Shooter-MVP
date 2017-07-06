using UnityEngine;

public class EnemyBulletCollision : MonoBehaviour {

    private GameObject playerGameObject;
    private PlayerScript playerScript;

    void Start () {
        playerGameObject = GameObject.Find (Constants.Tag.PLAYER);
        playerScript = playerGameObject.GetComponent<PlayerScript> ();
    }

    void OnCollisionEnter (Collision collision) {
        if (collision.gameObject.tag == Constants.Tag.BULLET) {
            playerScript.player.incrementEnemyKills ();
            Destroy (gameObject);
            Destroy (collision.gameObject);
        }
    }
}
