using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour {
	void OnBecameInvisible () {
		Destroy (gameObject);
	}
}
