using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

	public PlayerHealth playerHealth;
	private Animator animator;

	void Awake (){
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		if (playerHealth.IsPlayerDead() == true)
		{
			animator.SetTrigger(Constants.Trigger.GAME_OVER);
		}
	}
}
