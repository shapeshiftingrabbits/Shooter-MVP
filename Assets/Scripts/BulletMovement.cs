using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {
	void OnBecameInvisible () {
		Destroy (gameObject);
	}
}
