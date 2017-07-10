using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour {

    public int startingHealth;
    public int currentHealth;
    public Slider healthSlider;
    private bool isDead;

    void Awake(){
        currentHealth = startingHealth;
        healthSlider.value = currentHealth;
        isDead = false;
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

    public bool IsPlayerDead(){
        return currentHealth <= 0;
    }
}
