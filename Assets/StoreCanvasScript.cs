using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreCanvasScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    // Update is called once per frame
    

    public void CloseStore()
    {
        player.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
    }
}
