using Managers;
using UnityEngine;

public class GameOverEvent : MonoBehaviour
{
    public GameObject gameOverManagerObject;

    public void OnGameOverAnimationEnd()
    {
        GameOverManager gameOverManager = gameOverManagerObject.GetComponent<GameOverManager>();
        gameOverManager.enableListeningForUserInput();
    }

}