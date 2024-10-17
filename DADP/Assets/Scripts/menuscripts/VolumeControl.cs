using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;  

    void Start()
    {
        
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);

        
        AdjustVolume(volumeSlider.value);

       
        volumeSlider.onValueChanged.AddListener(AdjustVolume);
    }

    
    public void AdjustVolume(float volume)
    {
        AudioListener.volume = volume;

        
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
