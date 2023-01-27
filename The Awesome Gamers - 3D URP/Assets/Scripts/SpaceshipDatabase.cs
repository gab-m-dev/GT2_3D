using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpaceshipDatabase : ScriptableObject
{
    // Start is called before the first frame update
    public Spaceship[] spaceship;

    public int spaceshipCount
    {
        get { 
            return spaceship.Length;
        }
    }

    public Spaceship GetSpaceship(int index)
    {
        return spaceship[index];
    }
}
