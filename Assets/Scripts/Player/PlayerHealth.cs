using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour {

	public int startingHealth;
	public int currentHealth;
	public Slider healthSlider;
    public bool isDead;


    void Awake(){
		currentHealth = startingHealth;
        healthSlider.value = currentHealth;
		isDead = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage(int amount){
		currentHealth -= amount;
		UpdateHealthUI();
		if (currentHealth <= 0 && !isDead){
			Death();
		}
	}

	void Death(){
		isDead = true;
	}

	void UpdateHealthUI(){
		healthSlider.value = currentHealth;
	}

}
