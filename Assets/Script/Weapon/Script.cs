using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    public GameObject triangle;
    public SpriteRenderer spriteRenderer;
    public static Script instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        triangle.SetActive(false);
        //GunContainer = GetComponentInChildren<GunContainer>();

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
    public void ChangeGun(GameObject gunIndex)
    {
        Debug.Log(gunIndex);
        spriteRenderer.sprite= gunIndex.GetComponent<SpriteRenderer>().sprite;
        gameObject.tag = gunIndex.gameObject.tag;
    }
}
