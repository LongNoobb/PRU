using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateBar(currentHealth, maxHealth);
    }

    public void TakeDamegeHealth(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            gameObject.SetActive(false);
        }
        healthBar.UpdateBar(currentHealth, maxHealth);
    }

    public void AddHealth()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bulletEnemy"))
        {
            int damage = 1;
            if (PlayerArmor.instance.currentArmor <= PlayerArmor.instance.maxArmor && PlayerArmor.instance.currentArmor > 0)
            {
                PlayerArmor.instance.TakeDamageArmor(damage);
            }
            else if (PlayerArmor.instance.currentArmor <= 0)
            {
                TakeDamegeHealth(damage);
            }
            // Optionally, you might want to destroy the bullet
            Destroy(other.gameObject);
        }
    }
}
