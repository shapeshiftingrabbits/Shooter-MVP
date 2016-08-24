using UnityEngine;
using System.Collections;

public class EnemyBulletCollision : MonoBehaviour {

	private string bulletTag = "Bullet";

	void OnTriggerEnter (Collider other) {
		Debug.Log ("Entered trigger");

		if (other.gameObject.tag == bulletTag) {
			Destroy (gameObject);
		}
	}
}
