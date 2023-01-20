using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{

    public float powerUpDuration;
    private float damage;
    private float points;
    public Text PowerUpText;

    // Start is called before the first frame update
    void Start()
    {
        damage = 1f;
        points = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getDamage(){
        return damage;
    }

    public float getPoint(){
        return points;
    }

    public void ActivateShield(){
        damage = 0f;
        PowerUpText.text = "PowerUp: Shield";
        StartCoroutine(Shiled());
    }

    public void ActivateDoublePoints(){
        points = 2f;
        PowerUpText.text = "PowerUp: Double Points";
        StartCoroutine(DoublePoints());
    }

    IEnumerator Shiled(){       
        yield return new WaitForSeconds(powerUpDuration);
        damage = 1f;
        PowerUpText.text = "PowerUp: -";
    }

    IEnumerator DoublePoints(){       
        yield return new WaitForSeconds(powerUpDuration);
        points = 1f;
        PowerUpText.text = "PowerUp: -";
    }
}
