using UnityEngine;

public class MovementController
{
    public float MovementSpeed { get; set; } = 0f;
    public float RotationSpeed { get; set; } = 0f;

    public MovementController(float movementSpeed, float rotationSpeed)
    {
        MovementSpeed = movementSpeed;
        RotationSpeed = rotationSpeed;
    }

    public Quaternion NextRotation(Vector3 position, Vector3 forward, Vector3 targetPosition, float deltaTime)
    {
        return Quaternion.LookRotation(
            NextDirection(position, forward, targetPosition, deltaTime)
        );
    }

    public Vector3 NextDirection(Vector3 position, Vector3 forward, Vector3 targetPosition, float deltaTime)
    {
        return Vector3.RotateTowards(
            forward,
            targetPosition - position,
            deltaTime * RotationSpeed,
            0f
        );
    }

    public Vector3 NextPosition(Vector3 position, Vector3 forward, float deltaTime)
    {
        return position + (Velocity(forward) * deltaTime);
    }

    public Vector3 Velocity(Vector3 forward) {
        return forward * MovementSpeed;
    }
}
