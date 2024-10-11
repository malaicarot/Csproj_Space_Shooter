using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Enemy : MonoBehaviour
{

    [SerializeField] int maxHealth = 100;
    public int currentHealth;
    [SerializeField] public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    public void TakeDamage(int dame)
    {
        currentHealth -= dame;
        healthBar.SetHealth(currentHealth);

    }


}
