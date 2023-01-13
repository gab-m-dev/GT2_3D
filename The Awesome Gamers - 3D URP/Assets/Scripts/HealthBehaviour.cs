using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBehaviour : MonoBehaviour
{

    public float MaxHitPoints;
    public float HitPoints;
    public Text HealthText;
    // Start is called before the first frame update
    void Start()
    {
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
        if(HitPoints <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
