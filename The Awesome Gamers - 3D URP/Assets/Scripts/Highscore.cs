using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    // Start is called before the first frame update
    int score;
    public static Highscore inst;
    public Text highScoreText;

     // The name of the player who achieved the high score
    public string highScoreName;

    // The key to use for storing the high score in PlayerPrefs
    public string highScoreKey;

    public void highScoreTracker(){
        score++;
        highScoreText.text = "Coins: " + score;
    }

    void Awake(){
        // sets inst static variable to refer to the current highscore component
        inst = this;

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
