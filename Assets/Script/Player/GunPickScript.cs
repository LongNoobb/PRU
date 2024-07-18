using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunPickScript : MonoBehaviour
{
    public GunContainer weapon;
    public PlayerHealth PlayerHealth;
    private bool isDesertEagle = false;
    private bool isGatling = false;
    private bool isK98 = false;
    private bool isM4A1 = false;
    private bool isBuff = false;
    private GameObject[] weapons;
    public PickBuffScript pickBuff;
    private void Start()
    {
        weapon = GetComponentInChildren<GunContainer>();
        weapons = weapon.weapons;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isGatling)
            {
                TurnOffAllWeapon();
                weapons[1].SetActive(true);
                ChangeGun.instance.ChangeGunFuction(weapon.currentWeapon);
                weapon.currentWeaponIndex = 1;
                weapon.currentWeapon = weapons[1];
                isGatling = false;
            }
            else if (isDesertEagle)
            {
                TurnOffAllWeapon();
                weapons[0].SetActive(true);
                ChangeGun.instance.ChangeGunFuction(weapon.currentWeapon);
                weapon.currentWeaponIndex = 0;
                weapon.currentWeapon = weapons[0];
                isDesertEagle = false;
            }
            else if (isM4A1)
            {
                TurnOffAllWeapon();
                weapons[3].SetActive(true);
                ChangeGun.instance.ChangeGunFuction(weapon.currentWeapon);
                weapon.currentWeaponIndex = 3;
                weapon.currentWeapon = weapons[3];
                isM4A1 = false;
            }
            else if (isK98)
            {
                TurnOffAllWeapon();
                weapons[2].SetActive(true);
                ChangeGun.instance.ChangeGunFuction(weapon.currentWeapon);
                weapon.currentWeaponIndex = 2;
                weapon.currentWeapon = weapons[2];
                isK98 = false;
            }
            else if (isBuff)
            {
                pickBuff.PickBuff();
                isBuff = false;
            }

        }

    }

    private void TurnOffAllWeapon()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DesertEagle"))
        {
            isDesertEagle = true;
            Debug.Log("DEEEEEEEEEE");
        }
        else if (collision.gameObject.CompareTag("Gatling"))
        {

            isGatling = true;
            Debug.Log("GAlingggggg");
        }
        else if (collision.gameObject.CompareTag("K98"))
        {
            isK98 = true;
            Debug.Log("K98");
        }
        else if (collision.gameObject.CompareTag("M4A1"))
        {
            isM4A1 = true;
            Debug.Log("M4A1");
        }
        else if (collision.gameObject.CompareTag("HealthBuff"))
        {
            isBuff = true;
            Debug.Log("Bufffff");
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isDesertEagle = false;
        isGatling = false;
        isK98 = false;
        isM4A1 = false;
        isBuff = false;
    }
}
