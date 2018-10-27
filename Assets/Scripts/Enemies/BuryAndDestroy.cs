using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class BuryAndDestroy : MonoBehaviour {

    private Rigidbody[] rigidbodies;
    private float elapsedTimeBeforeBurying = 0f;
    private float elapsedTimeBeforeDestroying = 0f;
    public float delayBeforeBurying = 10f;
    public float burySpeed = 0.0002f;
    public float delayBeforeDestroying = 10f;
    private bool rigidbodiesDisabled = false;

    void Start () {
        rigidbodies = gameObject.GetComponentsInChildren<Rigidbody>();
    }

    void FixedUpdate () {
        elapsedTimeBeforeBurying += Time.deltaTime;

        if (elapsedTimeBeforeBurying >= delayBeforeBurying) {
            elapsedTimeBeforeDestroying += Time.deltaTime;
            BuryBelowground();
        }
    }

    void DisableRigidbody (Rigidbody rigidbody) {
        rigidbody.useGravity = false;
        rigidbody.detectCollisions = false;
        rigidbodiesDisabled = true;
    }

    void BuryBelowground () {
        if (rigidbodiesDisabled == false) {
            foreach (Rigidbody rigidbody in rigidbodies) {
                DisableRigidbody (rigidbody);
            }
        }

        gameObject.transform.position -= (Vector3.up * burySpeed);

        if (elapsedTimeBeforeDestroying >= delayBeforeDestroying) {
            Destroy(gameObject);
        }
    }
}
