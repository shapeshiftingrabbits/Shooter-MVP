using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Transform))]
public class CameraFollowTarget : MonoBehaviour {
    public GameObject target;
    private Vector3 startingPosition;
    Transform cameraTransform;

    void Start () {
        cameraTransform = GetComponent<Transform> ();
        startingPosition = cameraTransform.position;
    }

    void Update () {
        cameraTransform.position = cameraPosition();
    }

    Vector3 cameraPosition () {
        return new Vector3 (
            target.transform.position.x + startingPosition.x,
            cameraTransform.position.y,
            target.transform.position.z + startingPosition.z
        );
    }
}
