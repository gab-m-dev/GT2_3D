using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{

    private float damage;
    public Text PowerUpText;

    // Start is called before the first frame update
    void Start()
    {
        damage = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getDamage(){
        return damage;
    }

    public void ActivateShield(){
        damage = 0f;
        PowerUpText.text = "PowerUp: Shield";
        StartCoroutine(Shiled());
    }

    // TODO
    public void ActivateDoublePoints(){

    }

    IEnumerator Shiled(){       
        yield return new WaitForSeconds(5f);
        damage = 1f;
        PowerUpText.text = "PowerUp: -";
    }
}
