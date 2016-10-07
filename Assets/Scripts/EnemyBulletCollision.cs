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
			Debug.Log (playerScript.player.EnemiesKilled());
			Destroy (gameObject);
			Destroy (other.gameObject);
		}
	}
}
