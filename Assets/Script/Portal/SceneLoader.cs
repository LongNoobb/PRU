using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNewScene(string sceneName)
    {
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        PlayerArmor playerArmor = FindObjectOfType<PlayerArmor>();
        GunContainer gunContainer = FindObjectOfType<GunContainer>();

        if (playerHealth != null)
        {
            GameManager.playerMaxHealth = playerHealth.maxHealth;
            GameManager.playerCurrentHealth = playerHealth.currentHealth;
        }

        if (playerArmor != null)
        {
            GameManager.playerMaxArmor = playerArmor.maxArmor;
            GameManager.playerCurrentArmor = playerArmor.currentArmor;
        }

        if (gunContainer != null)
        {
            GameManager.currentWeaponIndex = gunContainer.currentWeaponIndex;
        }

        SceneManager.LoadScene(sceneName);
    }
}
