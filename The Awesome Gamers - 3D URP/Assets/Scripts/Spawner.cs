using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Prefab for the coin that will be spawned
    public GameObject coinPrefab;

    // Distance between each coin
    public float spawnDistance = 10f;

    // How far in front of the player the coin spawning should start
    public float spawnStartDistance = 20f;

    // How far in front of the player the coin spawning should end
    public float spawnEndDistance = 40f;

    // List of all the spawned coins
    private List<GameObject> spawnedCoins = new List<GameObject>();

    // The player character
    private GameObject player;

    void Start()
    {
        // Find the player character
        player = GameObject.FindWithTag("Player");

        // Start the coin spawning coroutine
        StartCoroutine(SpawnCoins());
    }

    // Coroutine to spawn the coins
    IEnumerator SpawnCoins()
{
    while (true)
    {
        // Calculate the position to spawn the coin at
        float spawnPosition = player.transform.position.z + (player.GetComponent<Rigidbody>().velocity.z * Time.deltaTime) + spawnStartDistance + (spawnedCoins.Count * spawnDistance);

        // Check if the coin should be spawned
        if (spawnPosition < player.transform.position.z + spawnEndDistance)
        {
            // Spawn the coin
            GameObject coin = Instantiate(coinPrefab, new Vector3(0, 1, spawnPosition), Quaternion.identity);

            // Add the coin to the list of spawned coins
            spawnedCoins.Add(coin);
        }

        // Wait for the next coin spawn
        yield return new WaitForSeconds(0.1f);
    }
}

}
