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


    //Character selection
    public GameObject[] characters;
    public int selectedCharacter = 0;

    public static GameController instance;


    void Awake(){

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        
        }
     
}
    
   // Start is called before the first frame update
    void Start()
    {
    
        startButton.onClick.AddListener(StartGame);
        resetButton.onClick.AddListener(DeletePlayerPrefs);

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
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        
        Debug.Log("Halllooo");
        FindObjectOfType<AudioManager>().Stop("MenuMusic");
        FindObjectOfType<AudioManager>().Play("GameMusic");
        FindObjectOfType<AudioManager>().Play("ButtonSubmit");


        SceneManager.LoadScene("Game");
        
    }

    public void DeletePlayerPrefs(){

        PlayerPrefs.DeleteAll();
        FindObjectOfType<AudioManager>().Play("ButtonSubmit");
        highScoreText.text = "Highscore: " + 0;
        
    }

    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
    }

    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);
    }

}





