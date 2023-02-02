using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsBehaviour : MonoBehaviour
{

    public AudioManager audioManager;

    public bool obsticle;
    public bool shiled;
    public bool doublePoints;
    public bool blackHole;
    public bool rotorBlades;
    private PowerUp powerupManager;

    public GameObject aura;
    //public GameObject aura;

    // Start is called before the first frame update
    void Start()
    {
        // PowerUpManager ist für das Verhalten der einzelnen PowerUps
        powerupManager = FindObjectOfType<PowerUp>();
        audioManager = FindObjectOfType <AudioManager>();
        aura = GameObject.FindGameObjectWithTag("PowerUpAura");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (obsticle)
        {

            var player = collision.collider.GetComponent<HealthBehaviour>();
            if (player)
            {
                // audioManager.Play("AsteroidCollision");
                FindObjectOfType<AudioManager>().Play("Explosion");
                player.TakeHit(powerupManager.getDamage());
            }
        }
        else if (rotorBlades)
        {
            var player = collision.collider.GetComponent<HealthBehaviour>();
            if (player)
            {
                FindObjectOfType<AudioManager>().Play("Explosion");
                player.TakeHit(2f);
            }
        }
        else if (blackHole)
        {
            var player = collision.collider.GetComponent<HealthBehaviour>();
            if (player)
            {
                if (powerupManager.getDamage() != 0)
                {
                    FindObjectOfType<AudioManager>().Play("Explosion");
                    player.TakeHit(3f);
                }
            }
        }
        else if (doublePoints)
        {
            powerupManager.ActivateDoublePoints();
            FindObjectOfType<AudioManager>().Play("PowerUp");
        }
        else if (shiled)
        {
            powerupManager.ActivateShield();
            FindObjectOfType<AudioManager>().Play("PowerUp");
            aura.SetActive(true);
            
        }
        Destroy(gameObject);
    }
}

