using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOptionsManager : MonoBehaviour
{

    public static float musicVolume { get; private set; }
    public static float effectsVolume { get; private set; }

    public void OnMusicSliderValueChange(float value)
    {

        musicVolume = value;
        Debug.Log("Value: " + value);
        AudioManager.instance.UpdateMusicMixerVolume();
    }

    public void OnEffectsSliderValueChange(float value)
    {

        effectsVolume = value;
        Debug.Log("Value: " + value);
        AudioManager.instance.UpdateEffectsMixerVolume();
    }

}
