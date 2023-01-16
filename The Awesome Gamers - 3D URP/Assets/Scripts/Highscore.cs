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
    //public float score;
    //public string username;
    private ScoreData scoreData;
    public static Highscore inst;
    private List<ScoreData> scores;
    private const string SCORES_KEY = "scores";  

    public Text ScoreText;
    public Text highScoreText;
    
   

    //public ScoreManager scoreManager;
    public InputField inputName;
    public RowUI rowUI;
       //private Highscore Newhighscore = new Highscore("",0);


    public void increaseScore(float ammount){
        scoreData.score += ammount;
        ScoreText.text = " Score: " + scoreData.score;
       // Debug.Log(PlayerPrefs.GetFloat("Highscore", 0));
        
      // Highscore newScore = new Highscore(username, score);
      if(scores.Count > 0){
        if(scoreData.score > scores.First().score){
            highScoreText.text = "Highscore: " + scoreData.score.ToString();
        }
      } else {
        highScoreText.text = "Highscore: " + scoreData.score.ToString();
      }
        
    }




    void Awake(){
        // sets inst static variable to refer to the current highscore component
        inst = this;
       
    }
    void Start()
    {
        scores = new List<ScoreData>();
        LoadScoresFromJson();
        this.scoreData = new ScoreData(inputName.text, 0);
        if(scores.Count > 0){
            highScoreText.text = "Highscore:" + scores.First().score.ToString();
        }
       //updateTable();
        //scoreManager.LoadScoresFromJson();
        
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateList(){
        scores.Add(scoreData);
        scores = scores.OrderByDescending(x => x.score).ToList();
        saveScoreToJson();
        updateTable();
    }

    public void updateTable(){
          //float scoreBefore = PlayerPrefs.GetFloat("Highscore");
         //string usernameBefore = PlayerPrefs.GetString("Username");
          //   scoreManager.addScoreToList(new Highscore(usernameBefore, scoreBefore));
          //  scoreManager.addScoreToList(new Highscore("ivancho", 12));
          //  scoreManager.saveScoreToJson();
          // var scores = scoreManager.GetHighScore().ToArray();

            for(int i = 0; i < scores.Count; i++){
                var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
                row.rank.text = (i + 1).ToString();
                row.username.text = scores[i].username;
                row.score.text = scores[i].score.ToString();
            }

    }

    public void saveScoreToJson(){
        // Convert the scores list to a json string
        //string json = JsonUtility.ToJson(scores);
        string json = JsonConvert.SerializeObject(scores);
        // Save the json string to PlayerPrefs
        PlayerPrefs.SetString(SCORES_KEY, json);
    }


    public void LoadScoresFromJson(){
      
      if(PlayerPrefs.HasKey(SCORES_KEY)){
        // Load the json string from PlayerPrefs
        string json = PlayerPrefs.GetString(SCORES_KEY);
        Debug.Log(json);
        // Convert the json string back to a scores list
        List<ScoreData> importedScores = JsonConvert.DeserializeObject<List<ScoreData>>(json);
        if (importedScores is not null){
            scores = importedScores.OrderByDescending(x => x.score).ToList();
        }
      }
    }

    private void OnDestroy(){
        //saveScoreToJson();
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




















































































/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    // Start is called before the first frame update
    float score;
    public static Highscore inst;
    public Text ScoreText;
    public Text highScoreText;
    public GameController gc;
    public InputField inputName;

    string username;
    string data;


     void Start()
    {
       

         // Get the data string from PlayerPrefs
        string getData = PlayerPrefs.GetFloat("Highscore").ToString();
        Debug.Log(getData);
         username = PlayerPrefs.GetString("Username");
        Debug.Log(username);


        if(string.IsNullOrEmpty(data)){
            score = 0;
            username = "";
        }else{

            // Split the data string into an array of strings
        string[] dataArray = getData.Split(',');

        // Get the username and score from the array
        username = dataArray[0];
        Debug.Log("Test" + username);
        score = int.Parse(dataArray[1]);  
        Debug.Log("Score" + score);

        highScoreText.text = "Highscore:" + PlayerPrefs.GetFloat("Highscore", 0).ToString(); 

      // highScoreText.text =  "Highscore: " + username + " - " + PlayerPrefs.GetFloat("Highscore", 0).ToString();  
       Debug.Log(highScoreText.text);  

        }

          
    }


    void Awake(){
        // sets inst static variable to refer to the current highscore component
       
        inst = this;
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }


    public void increaseScore(float ammount){
        score += ammount;

       //data = username + "," + score;

        //PlayerPrefs.SetString("Score", data);

        ScoreText.text = " Score: " + score;
        //Debug.Log(PlayerPrefs.GetFloat("Highscore", 0));
        if(score > PlayerPrefs.GetFloat("Highscore", 0)){
            PlayerPrefs.SetFloat("Highscore", score);
            highScoreText.text = "Highscore: " + score.ToString();
        }
    }

    
}  */
