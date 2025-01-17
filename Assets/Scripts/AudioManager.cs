using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            return;
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        Play("Music");
    }
    
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.soundByteName == name);
        if(s == null)
        {
            return;
        }
        s.source.Play();
    }
}
