using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{

    public GameObject coinPrefab;
    private GameObject temp;
    //reusable pool of coins => reduces the number of objects that are created
    private Queue<GameObject> coinPool = new Queue<GameObject>();

     void Start()
    {
       StartCoroutine(spawnCoins(20));
    }

  
   IEnumerator  spawnCoins(int numberOfCoins){

        
        for(int i = 0; i < numberOfCoins; i++){
            // pause after each iteration => allows for coins to be spawned over multiple frames
            yield return new WaitForEndOfFrame();
            if(coinPool.Count > 0){
                temp = coinPool.Dequeue();
            }
                
            temp = Instantiate(coinPrefab);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>()); // set the pos of the just spawned coin equal to a random position in the collider
        }
    }

   Vector3 GetRandomPointInCollider(Collider collider) {
    Vector3 min = collider.bounds.min;
    Vector3 max = collider.bounds.max;

    // Generate a random position within the bounds of the collider using min and max
    Vector3 pos = new Vector3(
        Random.Range(min.x, max.x),
        Random.Range(min.y, max.y),
        Random.Range(min.z, max.z)
    );

    // Ensure that the position is on the collider
    pos = collider.ClosestPoint(pos);

    // Set the y value of the position to 1, otherwise coins spawn inside the ground
    pos.y = 1;

    return pos;
}

// when a coin is no longer needed, it can be returned to the pool to be reused later
    public void ReturnCoinToPool(GameObject coin){
    
        coin.SetActive(false);
        coinPool.Enqueue(coin);
    }
  

    
}
