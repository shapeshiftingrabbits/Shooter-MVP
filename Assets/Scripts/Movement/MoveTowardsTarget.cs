using UnityEngine;

public class MoveTowardsTarget : MonoBehaviour {
    private GameObject target;
    private float defaultMovementSpeed = 0f;
    private float defaultRotationSpeed = 0f;
    public MovementController movementController;

    void Awake ()
    {
        movementController = new MovementController(defaultMovementSpeed, defaultRotationSpeed);
    }

    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }

    void Update ()
    {
        Rotate (Time.deltaTime);
        Move (Time.deltaTime);
    }

    void Rotate (float deltaTime)
    {
        gameObject.transform.rotation = movementController.NextRotation (gameObject.transform.position, gameObject.transform.forward, target.transform.position, deltaTime);
    }

    void Move (float deltaTime)
    {
        gameObject.transform.position = movementController.NextPosition (gameObject.transform.position, gameObject.transform.forward, deltaTime);
    }
}
