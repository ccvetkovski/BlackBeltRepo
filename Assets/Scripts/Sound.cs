using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string soundByteName;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
