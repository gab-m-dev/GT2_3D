using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject controlsMenuUI;


    private void Start()
    {
        GameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            } else
            {
                Paused();
            } 
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Paused()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        controlsMenuUI.SetActive(true);
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Stop("GameMusic");
        FindObjectOfType<AudioManager>().Play("MenuMusic");
        FindObjectOfType<AudioManager>().Play("ButtonSubmit");
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
        
    }

    public void FreezeTime()
    {
        Time.timeScale = 0f;
    }

    public void NormalTime()
    {
        Time.timeScale = 1f;
    }
}