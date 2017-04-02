using UnityEngine;
using System.Collections;

public class MoveTowardsTarget : MonoBehaviour {
    private GameObject target;
    private float rotationSpeed = 1f;
    private float movementSpeed = 3f;

    public void SetTarget(GameObject newTarget) {
        target = newTarget;
    }

    void Update () {
        Rotate (Time.deltaTime);
        Move (Time.deltaTime);
    }

    void Rotate (float deltaTime) {
        gameObject.transform.rotation = nextRotation (deltaTime);
    }

    void Move (float deltaTime) {
        gameObject.transform.position += nextPosition(deltaTime);
    }

    Quaternion nextRotation(float deltaTime) {
        return Quaternion.LookRotation(nextLookDirection (deltaTime));
    }

    Vector3 nextLookDirection(float deltaTime) {
        return (
            Vector3.RotateTowards (
                gameObject.transform.forward,
                target.transform.position - gameObject.transform.position,
                deltaTime * rotationSpeed,
                0f
            )
        );
    }

    Vector3 nextPosition(float deltaTime) {
        return (gameObject.transform.forward * deltaTime * movementSpeed);
    }
}
