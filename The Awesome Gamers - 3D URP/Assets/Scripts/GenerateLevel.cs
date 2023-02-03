using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    

    public GameObject[] levelParts;
    public int zPos;
    private int startZPos;
    private bool isCreating = false;
    // Start is called before the first frame update
    void Start()
    {
        startZPos = zPos * 2;        
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
        int partNum = Random.Range(0, levelParts.Length);
        Instantiate(levelParts[partNum], new Vector3(0,0, startZPos), Quaternion.identity);
        
        startZPos += zPos;

     

        yield return new WaitForSeconds(1.25f);
        isCreating = false;
    }
}
