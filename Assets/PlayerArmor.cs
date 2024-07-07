using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmor : MonoBehaviour
{
    [SerializeField] public int maxArmor;
    public int currentArmor;
    public ArmorBar ArmorBar;
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
        currentArmor = maxArmor;
        ArmorBar.UpdateBar(currentArmor, maxArmor);
    }

    private void Update()
    {
        
        if (!isRegenerating && (Time.time - lastDamageTime >= timeHealArmor) && currentArmor < maxArmor)
        {
            StartCoroutine(RegenArmor());
        }
        Debug.Log(Time.time - lastDamageTime);
    }

    public void TakeDamageArmor(int damage)
    {
        currentArmor -= damage;
        if (currentArmor <= 0)
        {
            currentArmor = 0;
        }
        ArmorBar.UpdateBar(currentArmor, maxArmor);

        lastDamageTime = Time.time;
        
        if (isRegenerating)
        {
            StopCoroutine(RegenArmor());
            isRegenerating = false;
        }
    }

    private IEnumerator RegenArmor()
    {
        isRegenerating = true;

        while (currentArmor < maxArmor)
        {
            currentArmor++;
            ArmorBar.UpdateBar(currentArmor, maxArmor);
            yield return new WaitForSeconds(1f);

           
            if (Time.time - lastDamageTime < timeHealArmor)
            {
                isRegenerating = false;
                yield break;
            }
        }

        isRegenerating = false;
    }


}
