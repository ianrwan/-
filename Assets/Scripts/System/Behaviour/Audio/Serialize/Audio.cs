using System;
using UnityEngine;

namespace Megumin.GameSystem
{
    [Serializable]
    public class Audio
    {
        [Tooltip("Input the name of the sound you wanna find.")]
        [SerializeField] private string name;
        public string Name
        {
            get => name;
        }

        // [Tooltip("Input the audio clip. Like .mp3 or .ogg")]
        // [SerializeField] private AudioClip audioClip;
        // public AudioClip AudioClip
        // {
        //     get => audioClip;
        // }

        // [Range(0f, 1f)]
        // public float volume;

        // [Range(.1f, 3f)]
        // public float pitch;

        public AudioSource audioSource;
    }
}
