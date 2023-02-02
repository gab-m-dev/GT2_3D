using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float turnSpeed = 90f;
    private PowerUp powerupManager;
    
    void OnTriggerEnter(Collider collider){
    
        if(collider.gameObject.tag != "Player"){
            return;
        } 

        Highscore.inst.increaseScore(powerupManager.getPoint());
        FindObjectOfType<AudioManager>().Play("Collect");
        Destroy(gameObject);
    }

    
    // Start is called before the first frame update
    void Start()
    {
        powerupManager = FindObjectOfType<PowerUp>(); 
    }

    // Update is called once per frame
    void Update()
    {
        // rotates 90 degrees every second
        transform.Rotate(0,0, turnSpeed *  Time.deltaTime);
    }
}
