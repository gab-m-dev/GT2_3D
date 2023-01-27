using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLevelPart : MonoBehaviour
{

    private Transform playerTransform;
    //public GameObject endpoint;
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
        yield return new WaitForSeconds(3f);
        //Debug.Log(playerTransform.transform.position.z);
        Debug.Log(gameObject.transform.position.z);
        //Debug.Log(playerTransform.position.z - gameObject.transform.position.z);
        if (playerTransform.position.z - gameObject.transform.position.z > 650){
            
            Debug.Log("zerstoert");
            Destroy(gameObject);
        }
    }
}
