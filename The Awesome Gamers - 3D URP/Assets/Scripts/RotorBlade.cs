using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotorBlade : MonoBehaviour
{
    private PowerUp powerupManager;

    public float rotation;
  
    // Start is called before the first frame update
    void Start()
    {
        powerupManager = FindObjectOfType<PowerUp>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, rotation * Time.deltaTime, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var player = collision.collider.GetComponent<HealthBehaviour>();
        if (player)
        {
            player.TakeHit(powerupManager.getDamage());
        }
    }
}
