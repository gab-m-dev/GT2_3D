using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private bool gamePaused;
    public Button resetButton;
    public Button startButton;
    public InputField inputName;
    public DemoPlayerMovement dpm;
   // Start is called before the first frame update
void Start()
{
    startButton.onClick.AddListener(StoreUsername);
    startButton.onClick.AddListener(StartGame);
    resetButton.onClick.AddListener(DeletePlayerPrefs);

    gamePaused = true;
    Time.timeScale = 0;
}

// Update is called once per frame
void Update()
{
    // If player hits the escape key, toggle gamePaused variable
    if (Input.GetKeyDown(KeyCode.Escape))
    {
        gamePaused = !gamePaused;
    }

    // If game is not paused, set Time.timeScale to 1
    if (!gamePaused)
    {
        Time.timeScale = 1;
        resetButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        inputName.gameObject.SetActive(false);
    }
    else
    {
        Time.timeScale = 0;
        
    }
}


 public void StoreUsername(){
        // Store username in PlayerPrefs
        
        PlayerPrefs.SetString("Username", inputName.text);
        dpm.usernameText.text = "Username:" + " " + PlayerPrefs.GetString("Username");
    }


     public void StartGame(){
        // Store username in PlayerPrefs
        gamePaused = false;
        Time.timeScale = 1;
        
    }


    
    public void DeletePlayerPrefs(){

        PlayerPrefs.DeleteAll();
        dpm.highscoreText.text = "Highscore:" + "" + 0;
        dpm.usernameText.text = "Username:";
        dpm.distanceText.text = "Distance:" + "" + 0; 


    }


    

}





