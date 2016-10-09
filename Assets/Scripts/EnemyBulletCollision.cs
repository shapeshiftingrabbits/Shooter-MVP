using UnityEngine;
using System.Collections;

public class EnemyBulletCollision : MonoBehaviour {

	private GameObject playerGameObject;
	private PlayerScript playerScript;
	private string bulletTag = "Bullet";

	void Start () {
		playerGameObject = GameObject.Find ("Player");
		playerScript = playerGameObject.GetComponent<PlayerScript> ();
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == bulletTag) {
			playerScript.player.incrementEnemyKills ();
			Destroy (gameObject);
			Destroy (other.gameObject);
		}
	}
}
