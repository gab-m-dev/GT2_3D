using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Newtonsoft.Json;

[Serializable]
public class Highscore : MonoBehaviour
{
    // Start is called before the first frame update

    private ScoreData scoreData;
    public static Highscore inst;
    private List<ScoreData> scores;
    private const string SCORES_KEY = "scores";  

    public Text ScoreText;
    public Text usernameText;
    public Button startButton;
    
    public InputField inputName;
    public RowUI rowUI;

    void Awake(){
        // sets inst static variable to refer to the current highscore component
        inst = this;    
    }

    void Start()
    {
        startButton.onClick.AddListener(submitUsername);    
        scores = new List<ScoreData>();
        LoadScoresFromJson();
        this.scoreData = new ScoreData("", 0);
        usernameText.text = "Username: " + PlayerPrefs.GetString("username");
        updateTable();  
           
    }

    public void increaseScore(float ammount){
        scoreData.score += ammount;
        ScoreText.text = " Score: " + scoreData.score;
    }

    public void updateList(){
             
        scoreData.username =  PlayerPrefs.GetString("username");
        scores.Add(scoreData); 
        scores = scores.OrderByDescending(x => x.score).ToList();
        saveScoreToJson();
        updateTable();
    }

    public void submitUsername(){
        usernameText.text = inputName.text;     
        scoreData.username = inputName.text.ToString();
        PlayerPrefs.SetString("username",inputName.text);
    }

    public void updateTable(){
          //float scoreBefore = PlayerPrefs.GetFloat("Highscore");
         //string usernameBefore = PlayerPrefs.GetString("Username");
          //   scoreManager.addScoreToList(new Highscore(usernameBefore, scoreBefore));
          //  scoreManager.addScoreToList(new Highscore("ivancho", 12));
          //  scoreManager.saveScoreToJson();
          // var scores = scoreManager.GetHighScore().ToArray();

            for(int i = 0; i < 3; i++){
                var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
                row.rank.text = (i + 1).ToString();
                row.username.text = scores[i].username;
                row.score.text = scores[i].score.ToString();
            }

    }

    private void saveScoreToJson(){
        // Convert the scores list to a json string
        string json = JsonConvert.SerializeObject(scores);
        Debug.Log(json);
        // Save the json string to PlayerPrefs
        PlayerPrefs.SetString(SCORES_KEY, json);

    }


    private void LoadScoresFromJson(){
      
      if(PlayerPrefs.HasKey(SCORES_KEY)){
        // Load the json string from PlayerPrefs
        string json = PlayerPrefs.GetString(SCORES_KEY);
        //Debug.Log(json);
        // Convert the json string back to a scores list
        List<ScoreData> importedScores = JsonConvert.DeserializeObject<List<ScoreData>>(json);
        if (importedScores is not null){
            scores = importedScores.OrderByDescending(x => x.score).ToList();
        }
      }
    }

    private void OnDestroy(){
        saveScoreToJson();
    }

}

public class ScoreData {

    public float score;
    public string username;

    public ScoreData(string username, float score){
        this.username = username;
        this.score = score;
    }

}
