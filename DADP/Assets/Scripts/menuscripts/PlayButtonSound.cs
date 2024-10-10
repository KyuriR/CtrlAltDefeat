using UnityEngine;
using UnityEngine.EventSystems;

public class PlayButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public AudioSource audioSource;

    void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    // Play sound when mouse hovers over the button
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (audioSource != null)
            audioSource.Play();
    }

    // Play sound when button is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        if (audioSource != null)
            audioSource.Play();
    }
}

