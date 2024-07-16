using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public static PauseMenu instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        pauseMenu.SetActive(false);
    }


    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        //Debug.Log("Quit");
        //Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
        
    }
}
