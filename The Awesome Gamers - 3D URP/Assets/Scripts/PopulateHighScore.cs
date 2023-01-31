using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using Newtonsoft.Json;

public class PopulateHighScore : MonoBehaviour
{

    private List<ScoreData> scores;
    private const string SCORES_KEY = "scores";
    public TextMeshProUGUI topFiveHighscores;
    public TextMeshProUGUI currentScoreTxt;

    private float currentScore;

    // Start is called before the first frame update
    void Start()
    {
        scores = new List<ScoreData>();
        LoadScoresFromJson();
        currentScore = PlayerPrefs.GetFloat("currentScore");
        populateTopFiveHighscores();
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

    private void populateTopFiveHighscores()
    {
        currentScoreTxt.text = currentScore.ToString();
        if (topFiveHighscores is not null)
        {
            if (scores.Count > 5)
            {
                topFiveHighscores.text =  scores[0].username + ":                               " + scores[0].score + "\n" + scores[1].username + ":                               " + scores[1].score + "\n" + scores[2].username + ":                               " + scores[2].score + "\n" + scores[3].username + ":                               " + scores[3].score;
            }
            else if (scores.Count > 0)
            {
                int size = scores.Count;
                string message = " ";
                for (int i = 0; i < size; i++)
                {
                    message += scores[i].username + ":                               " + scores[i].score + "\n";
                }
                topFiveHighscores.text = message;
            }
        }
    }
}
