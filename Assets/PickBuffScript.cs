using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickBuffScript : MonoBehaviour
{
    //public PlayerHealth health;
    public GameObject triangle;
    public static PickBuffScript instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        triangle.SetActive(false);
    }
    public void PickBuff()
    {
        gameObject.SetActive(false);
        Debug.Log(gameObject.name);
        //health.AddHealth();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            triangle.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            triangle.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            triangle.SetActive(false);
        }
    }

}
