using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {
	private float movementSpeed = 5f;

	void Update () {
		gameObject.transform.position += nextPosition(Time.deltaTime);
	}

	Vector3 nextPosition(float deltaTime) {
		return (gameObject.transform.up * deltaTime * movementSpeed);
	}

	void OnBecameInvisible () {
		Destroy (gameObject);
	}
}
