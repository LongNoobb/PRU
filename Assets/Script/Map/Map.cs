using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Map : MonoBehaviour
{
    private List<GameObject> listObjects = new List<GameObject>();
    private int countEnemyInActive = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("WallBlock");
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }

        foreach (Transform obj in gameObject.transform)
        {
            if (obj.CompareTag("Enemy"))
            {
                listObjects.Add(obj.gameObject);
            }
        }
        Debug.Log(listObjects.Count);
    }

    // Update is called once per frame
    
    void Update()
    {
        
        //GameObject[] childrenWithTag = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject obj in listObjects)
        {
            if (!obj.activeInHierarchy) 
            {
                countEnemyInActive++;
            }
        }
        Debug.Log(countEnemyInActive);
        if (countEnemyInActive == listObjects.Count)
        {
            foreach (Transform obj in transform)
            {
                if (obj.CompareTag("WallBlock"))
                {
                    Debug.Log("WallBlock found in " + obj.name);

                    obj.gameObject.SetActive(true);
                }
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(collision.gameObject);
        }
    }

}
