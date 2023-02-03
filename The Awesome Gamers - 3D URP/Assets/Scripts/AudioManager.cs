using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioMixerGroup musicMixerGroup;
    [SerializeField] private AudioMixerGroup soundEffectsMixerGroup;

    public Sound[] sounds;

    public static AudioManager instance;

    public double sliderValue = 1;

    //Add Music and Effect sliders

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            switch (s.audioType)
            {
                case Sound.AudioTypes.soundEffect:
                    s.source.outputAudioMixerGroup = soundEffectsMixerGroup;
                    break;
                case Sound.AudioTypes.music:
                    s.source.outputAudioMixerGroup = musicMixerGroup;
                    break;
            }
        }
    }

    void Start()
    {
        Play("MenuMusic");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found");
            return;
        }
        s.source.Play();    
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found");
            return;
        }
        s.source.Stop();
    }

    public Sound[] getSounds()
    {
        return this.sounds;
    }

    public static AudioManager audioManager
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("No AudioManager set");

            }
            return instance;
        }
    }

    public void UpdateMusicMixerVolume()
    {
        musicMixerGroup.audioMixer.SetFloat("MusicVolume", Mathf.Log10(AudioOptionsManager.musicVolume) * 20);
        //Save("MusicVolume");
    }
    public void UpdateEffectsMixerVolume()
    {
        soundEffectsMixerGroup.audioMixer.SetFloat("SoundEffectVolume", Mathf.Log10(AudioOptionsManager.effectsVolume) * 20);
        //Save("SoundEffectVolume");
    }

    /*
    public void Save(string name)
    {
        if(name == "MusicVolume")
        {
            PlayerPrefs.SetFloat(name, musicSlider.value);
        } else if (name == "SoundEffectVolume")
        {
            PlayerPrefs.SetFloat(name, soundEffectSlider.value);
        }
       
    }

    public void Load()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        soundEffectsSlider.value = PlayerPrefs.GetFloat("SoundEffectVolume");
    }
    */
}
