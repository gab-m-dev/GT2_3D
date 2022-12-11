using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{

    public GameObject coinPrefab;
    private GameObject temp;

     void Start()
    {
        spawnCoins();
    }


   public void spawnCoins(){

        int numberOfCoins = 25;
        for(int i = 0; i < numberOfCoins; i++){
            temp = Instantiate(coinPrefab);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>()); // set the pos of the just spawned coin equal to a random position in the collider
        }
    }

    //return vector3 random position
    Vector3 GetRandomPointInCollider(Collider collider){
        Vector3 pos = new Vector3 (Random.Range(collider.bounds.min.x, collider.bounds.max.x),
        Random.Range(collider.bounds.min.y, collider.bounds.max.y),
        Random.Range(collider.bounds.min.z, collider.bounds.max.z));

    //Randbehandlung
    //checks if random position generated is on the collider
    // if it isnt, generate new value for the position that is on the collider
        if(pos != collider.ClosestPoint(pos)){
            pos = GetRandomPointInCollider(collider);
        }

        pos.y = 1;
        return pos;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
