using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
public class RoomTrigger : MonoBehaviour
{
    public List<EnemyMove> roomEnemies = new List<EnemyMove>();
    private CompositeCollider2D doorCollider;

    public BossMove roomBoss = new BossMove();
    private bool doorClosed = false;
    private int totalEnemies;
    private int defeatedEnemies = 0;
    public ChestScript openChest;

    private void Start()
    {
        doorCollider = GetComponent<CompositeCollider2D>();
        doorCollider.isTrigger = true;
        totalEnemies = roomEnemies.Count;
        if (roomBoss != null)
        {
            totalEnemies++; // Include the boss in the total count if present
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !doorClosed)
        {
            Debug.Log("Player entered the room");
            if (roomEnemies.Count > 0 || roomBoss != null)
            {
                StartCoroutine(CloseDoorAfterDelay());
                foreach (var enemy in roomEnemies)
                {
                    enemy.PlayerEnteredRoom();
                    enemy.GetComponent<EnemyHealth>().roomTrigger = this; // Link EnemyHealth to RoomTrigger
                }
                if (roomBoss != null)
                {
                    roomBoss.PlayerEnteredRoom();
                    roomBoss.GetComponent<EnemyHealth>().roomTrigger = this; // Link Boss to RoomTrigger
                    
                }
            }
        }
    }

    private IEnumerator CloseDoorAfterDelay()
    {
        yield return new WaitForSeconds(1f); // Adjust the delay as needed
        CloseDoor();
    }
    private void CloseDoor()
    {
        doorClosed = true;
        doorCollider.isTrigger = false; // Enable the collider to block passage
        Debug.Log("Door closed");
    }

    public void EnemyDefeated()
    {
        defeatedEnemies++;
        if (defeatedEnemies >= totalEnemies)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        //doorClosed = false;
        doorCollider.isTrigger = true; // Disable the collider to allow passage
        Debug.Log("Door opened");
        if(openChest!=null) openChest.ChestAppear();
    }

}