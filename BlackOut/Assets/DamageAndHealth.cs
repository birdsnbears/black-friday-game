using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAndHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;

        healthBar.SetMaxHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //when playerGets hurt
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }
    }
    
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
