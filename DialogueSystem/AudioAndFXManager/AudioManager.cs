using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource soundEffectsSource;
    private AudioSource musicSource;

    public AudioClip CurrentMusicClip => musicSource.clip; // Property to access the current music clip

    void Awake()
    {
        // Ensure there's only one AudioListener in the scene
        AudioListener audioListener = GetComponent<AudioListener>();
        if (audioListener == null)
        {
            audioListener = gameObject.AddComponent<AudioListener>();
        }

        // Add and configure AudioSources for sound effects and music
        soundEffectsSource = gameObject.AddComponent<AudioSource>();
        musicSource = gameObject.AddComponent<AudioSource>();

        // Configure the music source to loop
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
            // Only change the music if it's a different clip
            if (musicSource.clip != clip)
            {
                musicSource.clip = clip;
                musicSource.Play();
                Debug.Log("Playing new music: " + clip.name);
            }
        }
    }

    public void StopMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
            musicSource.clip = null;
            Debug.Log("Music stopped");
        }
    }
}
