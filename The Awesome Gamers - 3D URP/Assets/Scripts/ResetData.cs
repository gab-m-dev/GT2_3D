using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetData : MonoBehaviour
{
    public DemoPlayerMovement dpm;
  
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeletePlayerPrefs(){

        PlayerPrefs.DeleteAll();
        dpm.highscoreText.text = "Highscore:" + "" + 0;
        dpm.usernameText.text = "Username:";
        dpm.distanceText.text = "Distance:" + "" + 0; 


    }

   
}
