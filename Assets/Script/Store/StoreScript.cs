using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreScript : MonoBehaviour
{
    private bool inContactRange = false;

    // Update is called once per frame
    void Update()
    {
        if (inContactRange && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Store");
        }
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
