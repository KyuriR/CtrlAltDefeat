using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientRoom : MonoBehaviour
{
    public GameObject uiText;
    private bool hasTriggered = false;

    void Start()
    {
        if (uiText != null)
        {
            uiText.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            if (uiText != null)
            {
                uiText.SetActive(true);
            }
            hasTriggered = true;
        }
    }

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