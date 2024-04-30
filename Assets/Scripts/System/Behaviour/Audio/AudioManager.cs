using System;
using Megumin.GameSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance{get; private set;}
    public Audio[] audios;
    
    public void Awake()
    {
        instance = this;

        // if(audios == null || audios.Length == 0)
        // {
        //     return;
        // }

        // foreach(var audio in audios)
        // {
        //     audio.audioSource = gameObject.AddComponent<AudioSource>();
        //     audio.audioSource.clip = audio.AudioClip;
        //     audio.audioSource.volume = audio.volume;
        //     audio.audioSource.pitch = audio.pitch;
        // }
    }

    public void Play(string name)
    {
        Audio audio = GetAudios(name);
        if(audio.audioSource.isPlaying == false)
            audio.audioSource.Play();
    }

    public void Stop(string name)
    {
        Audio audio = GetAudios(name);
        audio.audioSource.Stop();
    }

    public Audio GetAudios(string name)
    {
        Audio audio = Array.Find(audios, audio => audio.Name == name);
        if(audio == null)
        {
            Debug.LogWarning("Can't find the audio in the AudioManager.");
        }

        return audio;
    }
}
