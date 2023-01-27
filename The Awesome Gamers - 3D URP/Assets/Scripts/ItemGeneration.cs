using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGeneration : MonoBehaviour
{
    public GameObject[] powerUps;
    public GameObject[] obsticles;
    public float changeForPowerUp;
    public GameObject[] itemSpots;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 zPos = new Vector3(0,0,gameObject.transform.position.z);

        // Generiern von PowerUps oder Hindernissen an Position von Empty GameObjects
        foreach(GameObject g in itemSpots)
        {
            // Erstllen einer Wahrscheinlichkeitsverteilung für Hindernis oder PowerUp
            int[] probDistribution = new int[500];
            for (int i = 0; i < probDistribution.Length; i++){
                if (i < changeForPowerUp * 100){
                    probDistribution[i] = 1;
                } else
                {
                    probDistribution[i] = 0;
                }
            }

            int randomIndex = Random.Range(0, probDistribution.Length);

            // Generierung eines zufälligen Items anhand Wahrscheinlichkeitsverteilung
            if (probDistribution[randomIndex] == 0){
                int randomIndexO = Random.Range(0, obsticles.Length);
                GameObject newObject = Instantiate(obsticles[randomIndexO], g.transform.position, Quaternion.identity);
                newObject.transform.parent = gameObject.transform;
            } else {
                int randomIndexP = Random.Range(0, powerUps.Length);
                GameObject newObject = Instantiate(powerUps[randomIndexP], g.transform.position, Quaternion.identity);
                newObject.transform.parent = gameObject.transform;
            }
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
