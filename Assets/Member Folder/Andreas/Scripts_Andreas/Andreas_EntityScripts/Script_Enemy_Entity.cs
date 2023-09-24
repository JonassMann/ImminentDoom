using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Enemy_Entity : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth = 100;

    public Script_Health_Gauge healthGauge; // Assign the health gauge in the Inspector.


    private void Start()
    {
        currentHealth = maxHealth;
        healthGauge.SetMaxHealth(maxHealth);
    }


    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        // Implement logic for handling damage, e.g., check for death.
        healthGauge.SetHealth(currentHealth);
    }

    public void Heal(float healing)
    {
        currentHealth = Mathf.Min(maxHealth, currentHealth + healing);
        // Implement logic for handling healing.
    }

    
}
