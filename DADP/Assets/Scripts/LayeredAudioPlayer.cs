using System.Collections;
using UnityEngine;

public class VoiceOverManager : MonoBehaviour
{
    public AudioSource[] audioSources;  // Array of AudioSources with assigned clips
    public float delayBetweenClips = 20f; // Delay between each clip in seconds

    private int currentClipIndex = 0;

    void Start()
    {
        StartCoroutine(PlayVoiceOversWithDelay());
    }

    IEnumerator PlayVoiceOversWithDelay()
    {
        while (currentClipIndex < audioSources.Length)
        {
            // Play the current audio clip
            audioSources[currentClipIndex].Play();
            Debug.Log("Playing clip: " + audioSources[currentClipIndex].clip.name);

            // Wait for the clip duration + delay before playing the next one
            yield return new WaitForSeconds(audioSources[currentClipIndex].clip.length + delayBetweenClips);

            // Move to the next clip
            currentClipIndex++;
        }
    }
}

