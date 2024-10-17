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

    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (audioSource != null)
            audioSource.Play();
    }

    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (audioSource != null)
            audioSource.Play();
    }
}

