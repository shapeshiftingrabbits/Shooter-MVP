using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameOverManager : MonoBehaviour
    {
        public const string GAME_OVER = "GameOver";
        public const string SCENE_MAIN = "Main";

        public PlayerHealth playerHealth;
        public Animator panelAnimator;
        private bool shouldListenUserInput = false;

        void Update()
        {
            HandleGameOverCheck();
        }

        private void HandleGameOverCheck()
        {
            if (playerHealth.IsDead() == true)
            {
                ShowGameOverPanel();
                if (shouldListenUserInput)
                {
                    if (Input.anyKey)
                    {
                        RestartLevel();
                    }
                }
            }
        }

        public void ShowGameOverPanel()
        {
            panelAnimator.SetTrigger(GAME_OVER);
        }

        internal void DisableListeningForUserInput()
        {
            shouldListenUserInput = false;
        }

        internal void EnableListeningForUserInput()
        {
            shouldListenUserInput = true;
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SCENE_MAIN);
        }
    }
}
