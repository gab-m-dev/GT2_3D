using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;

    private AudioManager audioManager;

    private void Awake()
    {


    }

    public void SetMusicLevel(float sliderValue)
    {
        //audioManager.sounds[0].volume = Mathf.Log10(sliderValue) * 20;
        mixer.SetFloat("MusicVolume", sliderValue);
    }
}
