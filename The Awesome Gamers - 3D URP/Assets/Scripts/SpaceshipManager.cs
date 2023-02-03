using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpaceshipManager : MonoBehaviour
{
    public SpaceshipDatabase spaceshipDB;

    public TMP_Text nameText;
    public GameObject spaceship;

    private int selectedShip = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("selectedCharacter"))
        {
            selectedShip = 0;
        } else
        {
            Load();
        }

        UpdateSpaceship(selectedShip);
    }

    // Update is called once per frame
    public void NextOption()
    {
        selectedShip++;
        if(selectedShip >= spaceshipDB.spaceshipCount)
        {
            selectedShip = 0;
        }
        UpdateSpaceship(selectedShip);
        Save();
    }

    public void BackOption()
    {
        selectedShip--;
        if(selectedShip <= 0)
        {
            selectedShip = spaceshipDB.spaceshipCount - 1;
        }
        UpdateSpaceship(selectedShip);
        Save();
    }

    private void UpdateSpaceship(int selectedShip)
    {
        Spaceship ship = spaceshipDB.GetSpaceship(selectedShip);
        spaceship = ship.spaceship;
        nameText.text = ship.spaceshipName;
    }

    private void Load()
    {
        selectedShip = PlayerPrefs.GetInt("selectedShip");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectedShip", selectedShip);
    }
}
