using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAndHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    private PlayerScore score;

    void Start()
    {
        currentHealth = maxHealth;

        healthBar.SetMaxHealth(currentHealth);

        score = GetComponent<PlayerScore>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        // check if health bar gets got
        if(currentHealth <= 0)
        {
            score.DropSweetDeal();
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }
    }
}
