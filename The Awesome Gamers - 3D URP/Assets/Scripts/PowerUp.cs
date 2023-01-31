using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{

    public float powerUpDurationShield;
    public float powerUpDurationDoublePoints;
    private float damage;
    private float points;
    public Text PowerUpText;

    public GameObject aura;

    // Start is called before the first frame update
    void Start()
    {
        damage = 1f;
        points = 1f;
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
        yield return new WaitForSeconds(powerUpDurationShield);
        damage = 1f;
        PowerUpText.text = "PowerUp: -";

        aura.SetActive(true);
    }

    IEnumerator DoublePoints(){       
        yield return new WaitForSeconds(powerUpDurationDoublePoints);
        points = 1f;
        PowerUpText.text = "PowerUp: -";
    }
}
