using UnityEngine;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.currentMap++;
            FindObjectOfType<SceneLoader>().LoadNewScene("Map " + GameManager.currentMap);
        }
    }
}