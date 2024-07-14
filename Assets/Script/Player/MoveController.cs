using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.GraphicsBuffer;

public class MoveController : MonoBehaviour
{
    [SerializeField]
    public float speed = 5f;
    private Vector3 moveInput;
    public Rigidbody2D rd;
    public SpriteRenderer characterSR;
    public GameObject[] listEnemy;
    private Animator anim;
    
    void Start()
    {
         rd = gameObject.GetComponent<Rigidbody2D>();
		anim = characterSR.GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        if(Mathf.Abs(moveInput.x)>0.01 || Mathf.Abs(moveInput.y) > 0.01)
        {
            anim.SetBool("isMoving", true);
        }else
        {
			anim.SetBool("isMoving", false);
		}
		rd.velocity = new Vector2(moveInput.x * speed, moveInput.y * speed);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            
         GameObject[] objects = GameObject.FindGameObjectsWithTag("TileMap");
            Debug.Log(objects.Length);
            foreach (GameObject obj in objects)
            {
                foreach (Transform child in obj.transform)
                {
                    if (child.name == "WallBlock")
                    {
                        child.gameObject.SetActive(true);
                    }
                    //if (childTransform != null)
                    //{
                    //    Debug.Log("WallBlock found in " + obj.name);
                    //    GameObject childGameObject = childTransform.gameObject;
                    //    childGameObject.SetActive(true);
                    //}
                }
                //    Transform childTransform = obj.transform.Find("WallBlock");
                //if (childTransform != null)
                //{
                //    GameObject childGameObject = childTransform.gameObject;
                //    childGameObject.SetActive(true);
                //}
            }

        }
    }

   


}
