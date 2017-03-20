using UnityEngine;
using System.Collections;

public class DestroyOnBecameInvisible : MonoBehaviour {
	void OnBecameInvisible () {
		Destroy (gameObject);
	}
}
