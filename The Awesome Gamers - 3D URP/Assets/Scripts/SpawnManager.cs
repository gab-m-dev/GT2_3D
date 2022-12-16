using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] asteroids;
    public int asteroidIndex;

    private float spawnRangeX = 15f;
    private float spawnRangeY = 15f;
    private float spawnPosZ = 400f;

    private float startDelay = 2f;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomAnimal()
    {
        asteroidIndex = Random.Range(0, asteroids.Length);

         //Randomly generate animal index and spawn position
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(-spawnRangeY, spawnRangeY), spawnPosZ);

        Instantiate(asteroids[asteroidIndex], spawnPos, asteroids[asteroidIndex].transform.rotation);
    }
}
