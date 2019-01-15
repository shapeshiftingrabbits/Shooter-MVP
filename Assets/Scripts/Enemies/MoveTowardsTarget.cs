using UnityEngine;

public class MoveTowardsTarget : MonoBehaviour {
    private GameObject target;
    private float rotationSpeed = 3f;
    private float movementSpeed = 10f;
    private MovementController movementController;

    void Awake ()
    {
        movementController = new MovementController(movementSpeed, rotationSpeed);
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
