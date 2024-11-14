using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientRoom : MonoBehaviour
{
    public GameObject uiText;
    private bool hasTriggered = false;
    //private object ui;

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
                StartCoroutine(DeactivateAfterDelay(7f));
            }
            hasTriggered = true;
        }
    }

    private IEnumerator DeactivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (uiText != null)
        {
            uiText.SetActive(false);
        }
    }
}