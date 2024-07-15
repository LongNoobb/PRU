using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the room");
            var enemies = FindObjectsOfType<EnemyMove>();
            foreach (var enemy in enemies)
            {
                enemy.PlayerEnteredRoom();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exit the room");
            var enemies = FindObjectsOfType<EnemyMove>();
            foreach (var enemy in enemies)
            {
                enemy.PlayerLeftRoom();
            }
        }
    }
}
