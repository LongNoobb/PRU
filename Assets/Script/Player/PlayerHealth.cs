using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;

    private void Start()
    {
        if (GameManager.playerMaxHealth > 0 && GameManager.playerCurrentHealth > 0)
        {
            maxHealth = GameManager.playerMaxHealth;
            currentHealth = GameManager.playerCurrentHealth;
        }
        else
        {
            currentHealth = maxHealth;
        }
        healthBar.UpdateBar(currentHealth, maxHealth);
    }

    public void TakeDamageHealth(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            gameObject.SetActive(false);
        }
        healthBar.UpdateBar(currentHealth, maxHealth);

        GameManager.playerCurrentHealth = currentHealth;
    }

    public void AddHealth()
    {
        maxHealth++;
        currentHealth++;
        healthBar.UpdateBar(currentHealth, maxHealth);

        GameManager.playerMaxHealth = maxHealth;
        GameManager.playerCurrentHealth = currentHealth;
    }

    public void Heal()
    {
        currentHealth+=2;
        if (currentHealth >= maxHealth)
        {
            currentHealth=maxHealth;
        }
        healthBar.UpdateBar(currentHealth, maxHealth);

        GameManager.playerMaxHealth = maxHealth;
        GameManager.playerCurrentHealth = currentHealth;
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
                TakeDamageHealth(damage);
            }
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            int damage = 1;
            if (PlayerArmor.instance.currentArmor <= PlayerArmor.instance.maxArmor && PlayerArmor.instance.currentArmor > 0)
            {
                PlayerArmor.instance.TakeDamageArmor(damage);
            }
            else if (PlayerArmor.instance.currentArmor <= 0)
            {
                TakeDamageHealth(damage);
            }
        }
    }
}
