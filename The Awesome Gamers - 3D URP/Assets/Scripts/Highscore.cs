using System.Collections;
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

    public void increaseScore(float ammount){
        score += ammount;
        ScoreText.text = " Score: " + score;
        Debug.Log(PlayerPrefs.GetFloat("Highscore", 0));
        if(score > PlayerPrefs.GetFloat("Highscore", 0)){
            PlayerPrefs.SetFloat("Highscore", score);
            highScoreText.text = "Highscore: " + score.ToString();
        }
    }

    void Awake(){
        // sets inst static variable to refer to the current highscore component
        inst = this;
    }
    void Start()
    {
        highScoreText.text = "Highscore:" + PlayerPrefs.GetFloat("Highscore", 0).ToString();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
