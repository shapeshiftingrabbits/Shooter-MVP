using UnityEngine;

public class DestroyOnCollision : MonoBehaviour {
	
	public bool destroySelf;
	public bool destroyCollidingObject;

	void OnCollisionEnter (Collision collision) {
		if (destroyCollidingObject == true) {
			Destroy(collision.collider);
		}
		if (destroySelf == true) {
			Destroy(gameObject);
		}
	}
}
