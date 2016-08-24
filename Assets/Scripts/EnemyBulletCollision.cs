using UnityEngine;
using System.Collections;

public class EnemyBulletCollision : MonoBehaviour {

	private string bulletTag = "Bullet";

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == bulletTag) {
			Destroy (gameObject);
			Destroy (other.gameObject);
		}
	}
}
