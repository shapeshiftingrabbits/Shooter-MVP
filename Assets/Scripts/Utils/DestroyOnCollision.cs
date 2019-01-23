using UnityEngine;

public class DestroyOnCollision : MonoBehaviour {

    private const string BULLET_TAG = "Bullet";

    void OnCollisionEnter (Collision collision) {
        if (collision.gameObject.tag == BULLET_TAG)
        {
            Debug.Log("ignore collision  with other bullet");
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        } else
        {
            Destroy(gameObject);
        }

    }
}
