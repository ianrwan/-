using UnityEngine;

public class SceneMusicController : MonoBehaviour
{
    void Start()
    {
        MusicManager musicManager = FindObjectOfType<MusicManager>();
        if (musicManager != null)
        {
            musicManager.StopMusic();
        }
    }
}