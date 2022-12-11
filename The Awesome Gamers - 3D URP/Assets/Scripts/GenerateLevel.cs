using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{

    public GameObject[] levelParts;
    public int zPos;
    private int startZSize;
    private bool isCreating = false;
    // Start is called before the first frame update
    void Start()
    {
        startZSize = zPos;        
    }

    // Update is called once per frame
    void Update()
    {
        if(isCreating == false){
            isCreating = true;
            StartCoroutine(GenerateNewPart());
        }
    }

    IEnumerator GenerateNewPart(){
        // partNum = Random.Range(0, numberOfSections);
        Instantiate(levelParts[0], new Vector3(0,0, zPos), Quaternion.identity);
        zPos += startZSize;
        yield return new WaitForSeconds(0.5f);
        isCreating = false;
    }
}
