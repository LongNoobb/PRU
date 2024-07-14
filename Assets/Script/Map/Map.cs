using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Map : MonoBehaviour
{
    public List<GameObject> listObjects;
    private int countEnemyInActive = 0;
    private GameObject[] objects;
    // Start is called before the first frame update
    void Start()
    {
         objects = GameObject.FindGameObjectsWithTag("WallBlock");
        Debug.Log("slgnskdnvkjsdnj: "+objects.Length);
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
        Debug.Log("dfgbfjsdfhbgj: "+listObjects.Count);
    }

    // Update is called once per frame
    
    void Update()
    {
        countEnemyInActive = 0;
        //GameObject[] childrenWithTag = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject obj in listObjects)
        {
            if (!obj.activeInHierarchy) 
            {
                countEnemyInActive++;
            }
        }
        Debug.Log(countEnemyInActive);
        Debug.Log(listObjects.Count);
        Debug.Log(objects.Length);


        if (countEnemyInActive == listObjects.Count)
        {
            //foreach (Transform obj in transform)
            //{
            //    if (obj.CompareTag("WallBlock"))
            //    {
            //        Debug.Log("WallBlock found in " + obj.name);

            //        obj.gameObject.SetActive(true);
            //    }
            //}
            foreach(GameObject obj in objects)
            {
                obj.gameObject.SetActive(false);
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
