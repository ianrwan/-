using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip musicClip;
    private AudioSource audioSource;

    private static MusicManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true;
        PlayMusic();
    }

    public void PlayMusic()
    {
        if (musicClip == null)
        {
            Debug.LogWarning("Music not set!");
            return;
        }

        if (!audioSource.isPlaying)
        {
            audioSource.clip = musicClip;
            audioSource.Play();
        }
    }

    public void StopMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}