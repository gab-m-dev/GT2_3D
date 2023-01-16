using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{

    public enum AudioTypes { soundEffect, music }
    public AudioTypes audioType;

    [HideInInspector]
    public AudioSource source;

    public string name;

    public AudioClip clip;

    [Range(0.0001f, 1f)]
    public float volume;

    [Range(0f, 3f)]
    public float pitch;

    public bool loop;



}
