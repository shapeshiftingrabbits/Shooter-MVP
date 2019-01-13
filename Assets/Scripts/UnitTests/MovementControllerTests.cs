using UnityEngine;
using NUnit.Framework;

public class MovementControllerTests
{
    [TestCase(new float[] {1, 1}, new float[] {0, 0, 0}, new float[] {1, 1, 0}, new float[] {1, 1, 0}, 1f, ExpectedResult = new float[] {-0.270598054f, 0.65328151f, 0.270598054f, 0.65328151f})]
    [TestCase(new float[] {1, 1}, new float[] {0, 0, 0}, new float[] {1, 1, 0}, new float[] {-10, 10, 0}, 1f, ExpectedResult = new float[] {-0.443576813f, -0.550671935f, -0.443576813f, 0.550671995f})]
    public float[] NextRotationTest(float[] movementControllerArguments, float[] vectorPositionArguments, float[] vectorForwardArguments, float[] vectorTargetPositionArguments, float deltaTime)
    {
        MovementController movementController = new MovementController(movementControllerArguments[0], movementControllerArguments[1]);
        Vector3 position = new Vector3(vectorPositionArguments[0], vectorPositionArguments[1], vectorPositionArguments[2]);
        Vector3 forward = new Vector3(vectorForwardArguments[0], vectorForwardArguments[1], vectorForwardArguments[2]);
        Vector3 targetPosition = new Vector3(vectorTargetPositionArguments[0], vectorTargetPositionArguments[1], vectorTargetPositionArguments[2]);

        Quaternion result = movementController.NextRotation(position, forward, targetPosition, deltaTime);

        return new float[] {result.x, result.y, result.z, result.w};
    }

    [TestCase(new float[] {1, 1}, new float[] {0, 0, 0}, new float[] {1, 1, 0}, new float[] {1, 1, 0}, 1f, ExpectedResult = new float[] {1, 1, 0})]
    [TestCase(new float[] {1, 1}, new float[] {0, 0, 0}, new float[] {1, 1, 0}, new float[] {-10, 10, 0}, 1f, ExpectedResult = new float[] {-0.30116865f, 1.38177323f, 0})]
    public float[] NextDirectionTest(float[] movementControllerArguments, float[] vectorPositionArguments, float[] vectorForwardArguments, float[] vectorTargetPositionArguments, float deltaTime)
    {
        MovementController movementController = new MovementController(movementControllerArguments[0], movementControllerArguments[1]);
        Vector3 position = new Vector3(vectorPositionArguments[0], vectorPositionArguments[1], vectorPositionArguments[2]);
        Vector3 forward = new Vector3(vectorForwardArguments[0], vectorForwardArguments[1], vectorForwardArguments[2]);
        Vector3 targetPosition = new Vector3(vectorTargetPositionArguments[0], vectorTargetPositionArguments[1], vectorTargetPositionArguments[2]);

        Vector3 result = movementController.NextDirection(position, forward, targetPosition, deltaTime);

        return new float[] {result.x, result.y, result.z};
    }

    [TestCase(new float[] {1, 0}, new float[] {0, 0, 0}, new float[] {1, 1, 0}, 1f, ExpectedResult = new float[] {1, 1, 0})]
    [TestCase(new float[] {1, 0}, new float[] {0, 0, 0}, new float[] {1, 1, 0}, 2f, ExpectedResult = new float[] {2, 2, 0})]
    [TestCase(new float[] {5, 0}, new float[] {10, 2, 5}, new float[] {2, 1, 1}, 1f, ExpectedResult = new float[] {20, 7, 10})]
    [TestCase(new float[] {5, 0}, new float[] {10, 2, 5}, new float[] {2, 1, 1}, 2f, ExpectedResult = new float[] {30, 12, 15})]
    public float[] NextPositionTest(float[] movementControllerArguments, float[] vectorPositionArguments, float[] vectorForwardArguments, float deltaTime)
    {
        MovementController movementController = new MovementController(movementControllerArguments[0], movementControllerArguments[1]);
        Vector3 position = new Vector3(vectorPositionArguments[0], vectorPositionArguments[1], vectorPositionArguments[2]);
        Vector3 forward = new Vector3(vectorForwardArguments[0], vectorForwardArguments[1], vectorForwardArguments[2]);

        Vector3 result = movementController.NextPosition(position, forward, deltaTime);

        return new float[] {result.x, result.y, result.z};
    }

    [TestCase(new float[] {2, 0}, new float[] {2, 2, 3}, ExpectedResult = new float[] {4, 4, 6})]
    [TestCase(new float[] {3.5f, 0}, new float[] {10, 8, 9.5f}, ExpectedResult = new float[] {35, 28, 33.25f})]
    [TestCase(new float[] {27.8f, 0}, new float[] {65.2f, 24.7f, 4.75f}, ExpectedResult = new float[] {1812.55981f, 686.66f, 132.05f})]
    public float[] VelocityTest(float[] movementControllerArguments, float[] vectorForwardArguments)
    {
        MovementController movementController = new MovementController(movementControllerArguments[0], movementControllerArguments[1]);
        Vector3 forward = new Vector3(vectorForwardArguments[0], vectorForwardArguments[1], vectorForwardArguments[2]);

        Vector3 result = movementController.Velocity(forward);

        return new float[] {result.x, result.y, result.z};
    }
}
