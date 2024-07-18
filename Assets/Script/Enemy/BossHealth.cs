using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public GameObject healthBarUI;
    public Slider slider;
    public RoomTrigger roomTrigger;

    void Start()
    {
        currentHealth = maxHealth * 2; // Double the max health for the boss
        slider.value = CalculateHealth();
        healthBarUI.SetActive(false);
    }

    void Update()
    {
        slider.value = CalculateHealth();

        if (currentHealth < maxHealth * 2)
        {
            healthBarUI.SetActive(true);
        }
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            roomTrigger?.EnemyDefeated();
        }

        if (currentHealth > maxHealth * 2)
        {
            currentHealth = maxHealth * 2;
        }
    }

    float CalculateHealth()
    {
        return currentHealth / (maxHealth * 2);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            gameObject.SetActive(false);
            roomTrigger?.EnemyDefeated();
        }

        slider.value = CalculateHealth();
    }
}
