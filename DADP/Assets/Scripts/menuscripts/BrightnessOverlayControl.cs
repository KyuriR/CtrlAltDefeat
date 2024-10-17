using UnityEngine;
using UnityEngine.UI;

public class BrightnessOverlayControl : MonoBehaviour
{
    public Image brightnessOverlay;  
    public Slider brightnessSlider;  

    void Start()
    {
        
        brightnessSlider.value = 1f;
        brightnessSlider.onValueChanged.AddListener(AdjustBrightness);
    }

    void AdjustBrightness(float value)
    {
        Color overlayColor = brightnessOverlay.color;
        overlayColor = Color.Lerp(new Color(0f, 0f, 0f, 1f), new Color(0f, 0f, 0f, 0f), value); 
        brightnessOverlay.color = overlayColor;
    }
}
