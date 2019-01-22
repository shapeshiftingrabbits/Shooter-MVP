using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemySpeed", menuName = "ScriptableObjects/EnemySpeed", order = 1)]
public class EnemySpeedScriptableObject : ScriptableObject
{
    public float movementSpeed = 0f;
    public float rotationSpeed = 0f;

    public MovementController movementController()
    {
        return new MovementController(movementSpeed, rotationSpeed);
    }
}
