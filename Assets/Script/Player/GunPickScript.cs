using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunPickScript : MonoBehaviour
{
    public GunContainer weapon;
    public PlayerHealth PlayerHealth;
    private void Start()
    {
        weapon = GetComponentInChildren<GunContainer>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("pick123");
            GameObject[] weapons = weapon.weapons;
            

            // Reset all weapons
            for (int i = 0; i < weapons.Length; i++)
            {
                weapons[i].SetActive(false);
            }

            // Handle specific weapon activation
            if (collision.gameObject.CompareTag("DesertEagle"))
            {
                weapons[0].SetActive(true);
                Script.instance.ChangeGun(weapon.currentWeapon);
                weapon.currentWeapon = weapons[0];
            }
            else if (collision.gameObject.CompareTag("Gatling"))
            {
                weapons[1].SetActive(true);
                Script.instance.ChangeGun(weapon.currentWeapon);
                weapon.currentWeapon = weapons[1];
            }
            else if (collision.gameObject.CompareTag("K98"))
            {
                weapons[2].SetActive(true);
                Script.instance.ChangeGun(weapon.currentWeapon);
                weapon.currentWeapon = weapons[2];
            }
            else if (collision.gameObject.CompareTag("M4A1"))
            {
                weapons[3].SetActive(true);
                Script.instance.ChangeGun(weapon.currentWeapon);
                weapon.currentWeapon = weapons[3];
            }
            else if (collision.gameObject.CompareTag("HealthBuff"))
            {
                collision.gameObject.SetActive(false);
                PlayerHealth.AddHealth();
                weapon.currentWeapon.SetActive(true);
            }
            
        }
    }
}
