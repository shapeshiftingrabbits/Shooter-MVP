using UnityEngine;

public class DestroyOnCollision : MonoBehaviour {
    void OnCollisionEnter (Collision collision) {
        Destroy(gameObject);
}
