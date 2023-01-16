using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOptionsManager : MonoBehaviour
{

    public static float musicVolume { get; private set; }
    public static float soundEffectsVolume { get; private set; }

    public void OnMusicSliderValueChange(float value)
    {

        musicVolume = value;
        Debug.Log("Value: " + value);
        AudioManager.instance.UpdateMixerVolume();
    }

}
