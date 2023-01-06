using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

   
    public float turnSpeed = 90f;
    
    void OnTriggerEnter(Collider collider){
    
        

        if(collider.gameObject.name != "StarSparrow1"){
            return;
        } 

        Highscore.inst.increaseScore(1.0f);
        Destroy(gameObject);
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // rotates 90 degrees every second
        transform.Rotate(0,0, turnSpeed *  Time.deltaTime);
    }
}
