using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int musicIndex = 0;

    private void Start()
    {
        audioSource.clip = playlist[0]; 
        audioSource.Play();
        Debug.Log("Je suis la musique");
    }
    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }
    void PlayNextSong()
    {
        musicIndex = (musicIndex + 1) % playlist.Length;    
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }
}
