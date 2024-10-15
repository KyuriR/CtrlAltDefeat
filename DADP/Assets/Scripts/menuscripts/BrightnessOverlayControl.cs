using UnityEngine;
using UnityEngine.UI;

public class BrightnessOverlayControl : MonoBehaviour
{
    public Image brightnessOverlay;  // Reference to the overlay image
    public Slider brightnessSlider;  // Reference to the brightness slider

    void Start()
    {
        // Initialize the slider with a default value (1 means full brightness)
        brightnessSlider.value = 1f;

        // Add a listener to the slider to call AdjustBrightness whenever the value changes
        brightnessSlider.onValueChanged.AddListener(AdjustBrightness);
    }

    // Adjust the overlay color based on the slider value
    void AdjustBrightness(float value)
    {
        Color overlayColor = brightnessOverlay.color;

        // Set the overlay color to a dark shade when the slider is at its lowest
        overlayColor = Color.Lerp(new Color(0f, 0f, 0f, 1f), new Color(0f, 0f, 0f, 0f), value); // Dark gray


        brightnessOverlay.color = overlayColor;
    }
}
