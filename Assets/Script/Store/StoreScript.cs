using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreScript : MonoBehaviour
{
    private bool inContactRange = false;
    public GameObject store;
    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        if (inContactRange && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Store");
            store.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            player.SetActive(false);
        }
    }

    public void CloseStore()
    {
        player.SetActive(true);
        Time.timeScale = 1;
        store.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inContactRange = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inContactRange = false;
        }
    }
}
