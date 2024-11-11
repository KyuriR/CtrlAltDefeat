using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPrompts : MonoBehaviour
{
    public GameObject uiText;
    private bool hasTriggered = false;
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && hasTriggered)
        {
            if (uiText != null)
            {
                uiText.SetActive(false);
            }
        }
    }
}
