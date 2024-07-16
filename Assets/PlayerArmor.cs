using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmor : MonoBehaviour
{
    public int maxArmor;
    public int currentArmor;
    public ArmorBar armorBar;
    public static PlayerArmor instance;
    private float timeHealArmor = 5f;

    private float lastDamageTime;
    private bool isRegenerating = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (GameManager.playerMaxArmor > 0 && GameManager.playerCurrentArmor > 0)
        {
            maxArmor = GameManager.playerMaxArmor;
            currentArmor = GameManager.playerCurrentArmor;
        }
        else
        {
            currentArmor = maxArmor;
        }
        armorBar.UpdateBar(currentArmor, maxArmor);
    }

    private void Update()
    {
        if (!isRegenerating && (Time.time - lastDamageTime >= timeHealArmor) && currentArmor < maxArmor)
        {
            StartCoroutine(RegenArmor());
        }
    }

    public void TakeDamageArmor(int damage)
    {
        currentArmor -= damage;
        if (currentArmor <= 0)
        {
            currentArmor = 0;
        }
        armorBar.UpdateBar(currentArmor, maxArmor);

        lastDamageTime = Time.time;

        if (isRegenerating)
        {
            StopCoroutine(RegenArmor());
            isRegenerating = false;
        }

        GameManager.playerCurrentArmor = currentArmor;
    }

    private IEnumerator RegenArmor()
    {
        isRegenerating = true;

        while (currentArmor < maxArmor)
        {
            currentArmor++;
            armorBar.UpdateBar(currentArmor, maxArmor);
            yield return new WaitForSeconds(1f);

            if (Time.time - lastDamageTime < timeHealArmor)
            {
                isRegenerating = false;
                yield break;
            }
        }

        isRegenerating = false;
        GameManager.playerCurrentArmor = currentArmor;
    }
}
