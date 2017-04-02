using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class BuryAndDestroy : MonoBehaviour {

    private Rigidbody[] rigidbodies;
    private float elapsedTimeBeforeBurying = 0f;
    private float elapsedTimeBeforeDestroying = 0f;
    private float delayBeforeBurying = 10f;
    private float burySpeed = 0.0002f;
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
        rigidbody.isKinematic = true;
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

        if (elapsedTimeBeforeDestroying >= DelayBeforeDestroying()) {
            Destroy(gameObject);
        }
    }

    float DelayBeforeDestroying () {
        return ((1 / burySpeed) * 0.002f);
    }
}
