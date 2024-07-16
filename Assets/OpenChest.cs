using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
public class OpenChest : MonoBehaviour
{
    public GameObject ChestOpen;
    public GameObject ChestClose;
    public GameObject[] listItem;
    private Collider2D col;
    public List<EnemyMove> roomEnemies = new List<EnemyMove>();
    private bool isAppear = false;
    private void Start()
    {
        ChestClose.SetActive(false);

        int a= roomEnemies.Count;
        Debug.Log(a);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isAppear)
        {
            openChest();
        }
    }
    private void openChest()
    {
        ChestClose.SetActive(false);
        ChestOpen.SetActive(true);
        listItem[Random.Range(0, listItem.Length)].SetActive(true);
        col = GetComponent<Collider2D>();
        col.enabled = false;
    }
    private void ChestAppear()
    {
        ChestClose.SetActive(true);
    }

    private void Update()
    {
        int count = 0;
        foreach (EnemyMove move in roomEnemies)
        {
            if (move.gameObject.activeInHierarchy)
            {
                count++;
            }
        }
        if (count == roomEnemies.Count)
        {
            ChestAppear();
            isAppear = true;
        }
    }

}
