using UnityEngine;
using UnityEngine.UI;

public class BrightnessControl : MonoBehaviour
{
    public Slider brightnessSlider; // Reference to the Brightness Slider

    // Start is called before the first frame update
    void Start()
    {
        // Set initial brightness level (default is middle of the slider)
        brightnessSlider.value = PlayerPrefs.GetFloat("Brightness", 0.5f);
        AdjustBrightness(brightnessSlider.value);

        // Add listener to the slider to detect changes
        brightnessSlider.onValueChanged.AddListener(AdjustBrightness);
    }

    // Adjust the brightness when the slider is changed
    public void AdjustBrightness(float value)
    {
        // Here you can adjust the gamma or brightness of the game.
        // A common approach is to modify the global lighting or apply a brightness filter.

        RenderSettings.ambientLight = Color.white * value; // Adjusts ambient light

        // Save the value using PlayerPrefs so it persists between sessions
        PlayerPrefs.SetFloat("Brightness", value);
    }
}
