using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunContainer : MonoBehaviour
{
    int weaponTotal = 1;
    public static int currentWeaponIndex;
    public GameObject[] weapons;
    public GameObject weaponContainer;
    public GameObject currentWeapon;
    void Start()
    {
        weaponTotal = weaponContainer.transform.childCount;
        weapons = new GameObject[weaponTotal];
        for(int i=0; i<weaponTotal; i++)
        {
            weapons[i]= weaponContainer.transform.GetChild(i).gameObject;
            weapons[i].SetActive(false);  
        }
        weapons[0].SetActive(true);
        currentWeapon = weapons[0];
    }
}
