using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameOverManager : MonoBehaviour
    {
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
            panelAnimator.SetTrigger(Constants.Trigger.GAME_OVER);
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
            SceneManager.LoadScene(Constants.Scene.MAIN);
        }
    }
}