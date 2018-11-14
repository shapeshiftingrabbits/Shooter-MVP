using Player;
using UnityEngine;

namespace Managers
{
    public class GameOverManager : MonoBehaviour
    {

        public PlayerHealth playerHealth;
        private Animator animator;

        void Awake()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (playerHealth.IsDead() == true)
            {
                animator.SetTrigger(Constants.Trigger.GAME_OVER);
            }
        }
    }
}