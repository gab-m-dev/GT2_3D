using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLevelPart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyObjects());        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DestroyObjects(){
        yield return new WaitForSeconds(9f);
        foreach (Transform child in gameObject.transform) {
            GameObject.Destroy(child.gameObject);
        }
        Destroy(gameObject);
    }
}
