using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public const int maxHealth = 100;
    public int currentHealth = maxHealth;
 
    public Image health;
  
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        health.fillAmount = currentHealth / maxHealth;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Dead! GAME OVER");
        }
       
    }
}
