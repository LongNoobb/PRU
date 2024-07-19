using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
public class ChestScript : MonoBehaviour
{
    public GameObject ChestOpen;
    public GameObject ChestClose;
    public GameObject[] listItem;
    private Collider2D col;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            openChest();
        }
    }
    private void openChest()
    {
        ChestClose.SetActive(false);
        ChestOpen.SetActive(true);
        listItem[Random.Range(0, listItem.Length)].SetActive(true);
        pointManager.instance.AddPoint(Random.Range(10, 20));
        col = GetComponent<Collider2D>();
        col.enabled = false;
    }
    public void ChestAppear()
    {
        gameObject.SetActive(true);
        ChestClose.SetActive(true);
        ChestOpen.SetActive(false);
    }
}
