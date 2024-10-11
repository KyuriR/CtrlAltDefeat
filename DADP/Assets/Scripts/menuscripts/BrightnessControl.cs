using UnityEngine;
using UnityEngine.UI;

public class BrightnessControl : MonoBehaviour
{
    public Slider brightnessSlider;

    void Start()
    {
        // Load brightness setting or set to default 0.5 if not found
        brightnessSlider.value = PlayerPrefs.GetFloat("Brightness", 0.5f);
        AdjustBrightness(brightnessSlider.value);

        // Add listener to call AdjustBrightness when the slider value changes
        brightnessSlider.onValueChanged.AddListener(AdjustBrightness);
    }

    public void AdjustBrightness(float value)
    {
        // Debug to confirm the function is being called and the correct value is received
        Debug.Log("Brightness adjusted to: " + value);

        // Adjust the ambient light based on the slider value
        RenderSettings.ambientLight = Color.white * value;

        // Save the brightness value to PlayerPrefs
        PlayerPrefs.SetFloat("Brightness", value);
        PlayerPrefs.Save(); // Ensure the PlayerPrefs are saved immediately
    }
}
