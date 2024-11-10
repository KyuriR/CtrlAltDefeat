using System.Collections;
using UnityEngine;

public class VoiceOverManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] voiceOverClips;  // Array of voice-over clips
    public float delayBetweenClips = 20f; // Delay between each clip

    private int currentClipIndex = 0;

    void Start()
    {
        StartCoroutine(PlayVoiceOvers());
    }

    IEnumerator PlayVoiceOvers()
    {
        while (currentClipIndex < voiceOverClips.Length)
        {
            audioSource.clip = voiceOverClips[currentClipIndex];
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length + delayBetweenClips);
            currentClipIndex++;
        }
    }
}

