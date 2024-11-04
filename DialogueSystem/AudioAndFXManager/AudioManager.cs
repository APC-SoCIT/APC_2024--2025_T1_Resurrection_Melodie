using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource soundEffectsSource;
    private AudioSource musicSource;

    public AudioClip CurrentMusicClip => musicSource.clip;

    void Awake()
    {
        // Ensures that there is only one AudioListener in the scene
        GameObject audioCamera = GameObject.Find("Audio");
        AudioListener audioListener = audioCamera.GetComponent<AudioListener>();
        if (audioListener == null)
        {
            audioListener = audioCamera.AddComponent<AudioListener>();
        }

        // Add and configure AudioSources for sound effects and music
        soundEffectsSource = gameObject.AddComponent<AudioSource>();
        musicSource = gameObject.AddComponent<AudioSource>();
        // Configure the music source to loop until stopped
        musicSource.loop = true;
    }


    public void PlaySoundEffect(AudioClip clip)
    {
        if (clip != null)
        {
            soundEffectsSource.PlayOneShot(clip);
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip != null)
        {
            // Only change the music if a different music clip is used
            if (musicSource.clip != clip)
            {
                musicSource.clip = clip;
                musicSource.Play();
                // Debug.Log("Playing new music: " + clip.name);
            }
        }
    }

    public void StopMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
            musicSource.clip = null;
            // Debug.Log("Music stopped");
        }
    }
}
