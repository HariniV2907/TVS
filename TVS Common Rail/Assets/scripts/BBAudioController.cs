using UnityEngine;

public class BBAudioController : MonoBehaviour
{
    public AudioClip[] audioClips; // Array to hold the audio clips
    private AudioSource audioSource; // AudioSource component to play the audio clips
    private int currentIndex = 0; // Index to keep track of the current active audio clip

    void Start()
    {
        // Add an AudioSource component to this GameObject if it doesn't exist
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayNextAudio()
    {
        // Check if there are audio clips to play
        if (audioClips.Length == 0)
        {
            Debug.LogWarning("No audio clips assigned to play.");
            return;
        }

        // Play the next audio clip
        audioSource.clip = audioClips[currentIndex];
        audioSource.Play();

        // Increment the index and loop back to the beginning if necessary
        currentIndex = (currentIndex + 1) % audioClips.Length;
    }
}

