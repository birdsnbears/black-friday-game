using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAndHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    [SerializeField]
    float regenBufferInSeconds;
    [SerializeField]
    float regenInSeconds;
    [SerializeField]
    int regenAmount;

    public HealthBar healthBar;

    private PlayerScore score;
    private float regenTimer;

    void Start()
    {
        currentHealth = maxHealth;

        healthBar.SetMaxHealth(currentHealth);

        score = GetComponent<PlayerScore>();
    }

    // Update is called once per frame
    void Update()
    {
        // if you need some healing...
        if(currentHealth < maxHealth)
        {
            regenTimer += Time.deltaTime;

            if (regenTimer >= regenInSeconds)
            {
                heal();
                regenTimer -= regenInSeconds;
            }
        }
    }
    
    public void TakeDamage(int damage)
    {
        // trigger heal buffer
        regenTimer = 0 - regenBufferInSeconds;

        // inflict damage
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        // check if health bar completely depletes
        if(currentHealth <= 0)
        {
            // drop sweet deal and reset health
            score.DropSweetDeal();
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }
    }

    private void heal()
    {
        currentHealth = Mathf.Min(currentHealth + regenAmount, maxHealth);
        healthBar.SetHealth(currentHealth);
    }
}
