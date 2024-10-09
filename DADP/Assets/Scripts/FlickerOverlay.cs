using UnityEngine;
using UnityEngine.UI;

public class FlickerOverlay : MonoBehaviour
{
    public Image overlayImage; 
    public float flickerSpeed = 0.1f; 
    public float minAlpha = 0.2f; 
    public float maxAlpha = 0.8f; 

    private Color imageColor;

    void Start()
    {
        if (overlayImage == null)
            overlayImage = GetComponent<Image>();

        imageColor = overlayImage.color; 
    }

    void Update()
    {
        
        imageColor.a = Random.Range(minAlpha, maxAlpha);
        overlayImage.color = imageColor;

        
        Invoke("Update", flickerSpeed);
    }
}

