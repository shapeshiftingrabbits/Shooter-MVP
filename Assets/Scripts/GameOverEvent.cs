using UnityEngine;


namespace Managers
{
    public class GameOverEvent : MonoBehaviour
    {
        public GameObject gameOverManagerObject;

        public void OnGameOverAnimationEnd()
        {
            GameOverManager gameOverManager = gameOverManagerObject.GetComponent<GameOverManager>();
            gameOverManager.enableListeningForUserInput();
        }
    }
}

