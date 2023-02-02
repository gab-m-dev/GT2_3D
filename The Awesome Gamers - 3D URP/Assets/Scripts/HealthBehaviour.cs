using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBehaviour : MonoBehaviour
{

    public float MaxHitPoints;
    public float HitPoints;
    private Text HealthText;

    private bool isDead;
     
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        HealthText = GameObject.FindGameObjectWithTag("HealthText").GetComponent<Text>();
        HitPoints = MaxHitPoints;
        HealthText.text = "Health: " + HitPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeHit(float damage){
        
        HitPoints -= damage;
        HealthText.text = "Health: " + HitPoints;
        if(HitPoints <= 0 && isDead == false)
        {
            isDead = true;
            Highscore.inst.updateList();
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Stop("SpaceShip");
            FindObjectOfType<AudioManager>().Stop("GameMusic");
            FindObjectOfType<AudioManager>().Play("MenuMusic");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            Time.timeScale = 0;
           
        }
        
    }
}
