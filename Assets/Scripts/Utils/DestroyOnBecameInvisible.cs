using UnityEngine;

public class DestroyOnBecameInvisible : MonoBehaviour {
    void OnBecameInvisible () {
        Destroy (gameObject);
    }
}
