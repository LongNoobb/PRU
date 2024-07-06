using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunPickScript : MonoBehaviour
{
    public GunContainer weapon;
    
    private void Start()
    {
        weapon = GetComponentInChildren<GunContainer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DesertEagle") && Input.GetKeyDown(KeyCode.F))
        {
            weapon.weapons[0].SetActive(true);
            weapon.weapons[1].SetActive(false);
            weapon.weapons[2].SetActive(false);
            weapon.weapons[3].SetActive(false);
            Script.instance.ChangeGun(weapon.currentWeapon);
            weapon.currentWeapon = weapon.weapons[0];

        }
        else if (collision.gameObject.CompareTag("Gatling") && Input.GetKeyDown(KeyCode.F))
        {
            weapon.weapons[0].SetActive(false);
            weapon.weapons[1].SetActive(true);
            weapon.weapons[2].SetActive(false);
            weapon.weapons[3].SetActive(false);
            Script.instance.ChangeGun(weapon.currentWeapon);
            weapon.currentWeapon = weapon.weapons[1];

        }
        else if (collision.gameObject.CompareTag("K98") && Input.GetKeyDown(KeyCode.F))
        {
            weapon.weapons[0].SetActive(false);
            weapon.weapons[1].SetActive(false);
            weapon.weapons[2].SetActive(true);
            weapon.weapons[3].SetActive(false);
            Script.instance.ChangeGun(weapon.currentWeapon);
            weapon.currentWeapon = weapon.weapons[2];

        }
        else if (collision.gameObject.CompareTag("M4A1") && Input.GetKeyDown(KeyCode.F))
        {
            weapon.weapons[0].SetActive(false);
            weapon.weapons[1].SetActive(false);
            weapon.weapons[2].SetActive(false);
            weapon.weapons[3].SetActive(true);
            Script.instance.ChangeGun(weapon.currentWeapon);
            weapon.currentWeapon = weapon.weapons[3];

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DesertEagle") && Input.GetKeyDown(KeyCode.F))
        {
            
            weapon.weapons[0].SetActive(true);
            weapon.weapons[1].SetActive(false);
            weapon.weapons[2].SetActive(false);
            weapon.weapons[3].SetActive(false);
            Script.instance.ChangeGun(weapon.currentWeapon);
            weapon.currentWeapon = weapon.weapons[0];
            
        }
        else if (collision.gameObject.CompareTag("Gatling") && Input.GetKeyDown(KeyCode.F))
        {
            weapon.weapons[0].SetActive(false);
            weapon.weapons[1].SetActive(true);
            weapon.weapons[2].SetActive(false);
            weapon.weapons[3].SetActive(false);
            Script.instance.ChangeGun(weapon.currentWeapon);
            weapon.currentWeapon = weapon.weapons[1];

        }
        else if (collision.gameObject.CompareTag("K98") && Input.GetKeyDown(KeyCode.F))
        {
            weapon.weapons[0].SetActive(false);
            weapon.weapons[1].SetActive(false);
            weapon.weapons[2].SetActive(true);
            weapon.weapons[3].SetActive(false);
            Script.instance.ChangeGun(weapon.currentWeapon);
            weapon.currentWeapon = weapon.weapons[2];

        }
        else if (collision.gameObject.CompareTag("M4A1") && Input.GetKeyDown(KeyCode.F))
        {
            weapon.weapons[0].SetActive(false);
            weapon.weapons[1].SetActive(false);
            weapon.weapons[2].SetActive(false);
            weapon.weapons[3].SetActive(true);
            Script.instance.ChangeGun(weapon.currentWeapon);
            weapon.currentWeapon = weapon.weapons[3];

        }
    }
}
