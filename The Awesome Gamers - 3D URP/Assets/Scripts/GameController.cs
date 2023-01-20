using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private bool gameStarted;
    public Button resetButton;
    public Button startButton;
   
    public Text highScoreText;
     

    public Text rankLeaderboard;
    public Text usernameLeaderboard;
    public Text scoreLeaderboard;

    
    public RowUI rowUI;


    public GameObject Header;
    public GameObject Leaderboard;
    
    

void Awake(){
     DontDestroyOnLoad(this);
}
    
   // Start is called before the first frame update
void Start()
{
    
    startButton.onClick.AddListener(StartGame);
    resetButton.onClick.AddListener(DeletePlayerPrefs);
    //Header.gameObject.SetActive(false);
    //Leaderboard.gameObject.SetActive(false);

    gameStarted = true;
    Time.timeScale = 1;
}

// Update is called once per frame
void Update()
{
    // If player hits the escape key, toggle gameStarted variable
    if (Input.GetKeyDown(KeyCode.Escape))
    {
        gameStarted = !gameStarted;

    }

    // If game is not started, set Time.timeScale to 0
    if (!gameStarted)
    {
        Time.timeScale = 0;
     /*   resetButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        inputName.gameObject.SetActive(false);
        Header.gameObject.SetActive(false);
        Leaderboard.gameObject.SetActive(false); */
        
    }
    else
    {
        //resetButton.gameObject.SetActive(true);
        Time.timeScale = 1;
        //Header.gameObject.SetActive(true);
      //  Leaderboard.gameObject.SetActive(true);
    }
}


     public void StartGame(){
        // Store username in PlayerPrefs
    // usernameText.text = "Username:" + " " + PlayerPrefs.GetString("Username");

        gameStarted = true;
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
        
    }

    public void DeletePlayerPrefs(){

        PlayerPrefs.DeleteAll();
        highScoreText.text = "Highscore: " + 0;
        
    }


    

}





