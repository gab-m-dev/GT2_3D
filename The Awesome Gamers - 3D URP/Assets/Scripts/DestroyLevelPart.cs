using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLevelPart : MonoBehaviour
{

    private Transform playerTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindWithTag("PlayerTransform").transform;
        StartCoroutine(DestroyObjects());        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    IEnumerator DestroyObjects(){
        while(true){
            yield return new WaitForSeconds(3f);
     
            if ((gameObject.transform.position.z - playerTransform.position.z) < -650f){
                foreach (Transform child in gameObject.transform) {
                    GameObject.Destroy(child.gameObject);
                }
                Destroy(gameObject);
            }
        }
        
    }
}
