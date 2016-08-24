using UnityEngine;
using System.Collections;

public class MoveTowardsPlayer : MonoBehaviour {
	private GameObject player;
	private float rotationSpeed = 5f;
	private float movementSpeed = 3f;

	void Start () {
		player = GameObject.Find ("Player");
	}

	void Update () {
		Rotate (Time.deltaTime);
		Move (Time.deltaTime);
	}

	void Rotate (float deltaTime) {
		gameObject.transform.rotation = nextRotation (deltaTime);
	}

	void Move (float deltaTime) {
		gameObject.transform.position += nextPosition(deltaTime);
	}

	Quaternion nextRotation(float deltaTime) {
		return Quaternion.LookRotation(nextLookDirection (deltaTime));
	}

	Vector3 nextLookDirection(float deltaTime) {
		return (
			Vector3.RotateTowards (
				gameObject.transform.forward,
				player.transform.position - gameObject.transform.position,
				deltaTime * rotationSpeed,
				0f
			)
		);
	}

	Vector3 nextPosition(float deltaTime) {
		return (gameObject.transform.forward * deltaTime * movementSpeed);
	}
}
