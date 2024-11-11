using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Securityroomprompt : MonoBehaviour
{
    public GameObject uiText;
    public GameObject basementText;
    private bool hasTriggered = false;

    void Start()
    {
        if (uiText != null)
        {
            uiText.SetActive(false);
            basementText.SetActive(true);

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



