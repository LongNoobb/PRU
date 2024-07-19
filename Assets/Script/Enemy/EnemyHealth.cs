using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public GameObject healthBarUI;
    public Slider slider;
    public RoomTrigger roomTrigger;

    void Start()
    {
        currentHealth = maxHealth;
        slider.value = CalculateHealth();
        healthBarUI.SetActive(false); // Initially hide the health bar UI
    }

    void Update()
    {
        slider.value = CalculateHealth();

        if (currentHealth < maxHealth)
        {
            healthBarUI.SetActive(true);
        }
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            roomTrigger?.EnemyDefeated();
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    float CalculateHealth()
    {
        return currentHealth / maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            gameObject.SetActive(false);
            pointManager.instance.AddPoint(Random.Range(5,10));
            roomTrigger?.EnemyDefeated();
        }

        slider.value = CalculateHealth();
    }


}