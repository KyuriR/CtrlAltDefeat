using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;  // Reference to the slider

    void Start()
    {
        // Set the slider value to the saved volume value or default to 1 (full volume)
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);

        // Apply the saved volume value to the game's audio
        AdjustVolume(volumeSlider.value);

        // Add listener to detect changes in slider value
        volumeSlider.onValueChanged.AddListener(AdjustVolume);
    }

    // Method to adjust the volume based on slider value
    public void AdjustVolume(float volume)
    {
        AudioListener.volume = volume;

        // Save the volume value so it's persistent across game sessions
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
