using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsBehaviour : MonoBehaviour
{

    public bool obsticle;
    public bool shiled;
    public bool doublePoints;
    public bool blackHole;
    private PowerUp powerupManager;

    // Start is called before the first frame update
    void Start()
    {
        // PowerUpManager ist für das Verhalten der einzelnen PowerUps
        powerupManager = FindObjectOfType<PowerUp>();               
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {   
        if(obsticle){
            var player = collision.collider.GetComponent<HealthBehaviour>();
            if(player){
                player.TakeHit(powerupManager.getDamage());
            } 
        } else if(shiled) {
            powerupManager.ActivateShield();
        } else if (blackHole){
            var player = collision.collider.GetComponent<HealthBehaviour>();
            if(player){
                if(powerupManager.getDamage() != 0){
                    player.TakeHit(2f);
                }
            } 
        } else if (doublePoints) {
            powerupManager.ActivateDoublePoints();
        }
        Destroy(gameObject);
    }

}
