using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class BuryAndDestroy : MonoBehaviour {

	Rigidbody gameObjectRigidbody;
	float elapsedTimeBeforeBurying = 0f;
	float elapsedTimeBeforeDestroying = 0f;
	float delayBeforeBurying = 10f;
	float burySpeed = 0.0002f;
	bool rigidbodyDisabled = false;

	void Start () {
		gameObjectRigidbody = gameObject.GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
		elapsedTimeBeforeBurying += Time.deltaTime;

		if (elapsedTimeBeforeBurying >= delayBeforeBurying && gameObjectRigidbody.velocity == Vector3.zero) {
			elapsedTimeBeforeDestroying += Time.deltaTime;
			BuryBelowground();
		}
	}

	void DisableRigidbody () {
		gameObjectRigidbody.isKinematic = true;
		gameObjectRigidbody.useGravity = false;
		gameObjectRigidbody.detectCollisions = false;
		rigidbodyDisabled = true;
	}

	void BuryBelowground () {
		if (rigidbodyDisabled == false)
			DisableRigidbody ();

		gameObject.transform.position -= (Vector3.up * burySpeed);

		if (elapsedTimeBeforeDestroying >= DelayBeforeDestroying()) {
			Destroy(gameObject);
		}
	}

	float DelayBeforeDestroying () {
		return ((1 / burySpeed) * 0.002f);
	}
}
