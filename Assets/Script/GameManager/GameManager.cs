using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int playerMaxHealth;
    public static int playerCurrentHealth;
    public static int playerMaxArmor;
    public static int playerCurrentArmor;
    public static int currentWeaponIndex;

    private void Awake()
    {
        playerMaxHealth = 10;
        playerCurrentHealth = playerMaxHealth;
        playerMaxArmor = 6;
        playerCurrentArmor = playerMaxArmor;
        currentWeaponIndex = 0;
    }

    public void Initialize(int maxHealth, int currentHealth, int maxArmor, int currentArmor)
    {
        playerMaxHealth = maxHealth;
        playerCurrentHealth = currentHealth;
        playerMaxArmor = maxArmor;
        playerCurrentArmor = currentArmor;
    }
}
