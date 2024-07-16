using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public List<EnemyMove> roomEnemies = new List<EnemyMove>();

    public BossMove roomBoss = new BossMove();
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the room");
            foreach (var enemy in roomEnemies)
            {
                enemy.PlayerEnteredRoom();
            }
            roomBoss.PlayerEnteredRoom();
        }
    }

}