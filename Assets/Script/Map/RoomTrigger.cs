using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public List<EnemyMove> roomEnemies = new List<EnemyMove>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the room");
            foreach (var enemy in roomEnemies)
            {
                enemy.PlayerEnteredRoom();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the room");
            foreach (var enemy in roomEnemies)
            {
                enemy.PlayerLeftRoom();
            }
        }
    }
}