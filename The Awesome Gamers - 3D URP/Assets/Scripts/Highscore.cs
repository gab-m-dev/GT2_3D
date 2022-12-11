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

    public void highScoreTracker(){
        score++;
        highScoreText.text = "Highscore: " + score;
    }

    void Awake(){

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
