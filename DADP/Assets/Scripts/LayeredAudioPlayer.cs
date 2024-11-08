using UnityEngine;

public class LayeredAudioPlayer : MonoBehaviour
{
    public AudioSource backgroundMusicSource;  // Background music AudioSource
    public AudioSource voiceOverSource;        // Voice-over AudioSource
    public AudioClip[] voiceClips;             // Array of voice-over clips
    public float voiceVolume = 1.0f;           // Volume for voice-over clips

    void Start()
    {
        // Start playing background music
        if (backgroundMusicSource != null && backgroundMusicSource.clip != null)
        {
            backgroundMusicSource.loop = true; // Ensure looping
            backgroundMusicSource.Play();
        }
    }

    public void PlayVoiceClip(int clipIndex)
    {
        if (voiceOverSource != null && clipIndex < voiceClips.Length)
        {
            voiceOverSource.clip = voiceClips[clipIndex];
            voiceOverSource.volume = voiceVolume;
            voiceOverSource.Play();
        }
    }
}
