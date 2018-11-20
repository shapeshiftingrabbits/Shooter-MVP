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

        void Awake()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (playerHealth.IsDead() == true)
            {

                this.ShowGameOverPanel();
                if ( this.shouldListenUserInput)
                {
                    if (Input.anyKey)
                    {
                        this.RestartLevel();
                    }
                }
            }
        }

        public void ShowGameOverPanel()
        {
              panelAnimator.SetTrigger(Constants.Trigger.GAME_OVER);
        }

        internal void disableListeningForUserInput()
        {
            Debug.Log("disableListeningForUserInput");
            this.shouldListenUserInput = false;
        }

        internal void enableListeningForUserInput()
        {
            Debug.Log("enableListeningForUserInput");
            this.shouldListenUserInput = true;
        }

        public void RestartLevel()
        {
            Debug.Log("RestartLevel");
            SceneManager.LoadScene(Constants.Scene.MAIN);
        }

    }
}