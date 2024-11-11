using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyprompt : MonoBehaviour
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            StartCoroutine(ShowUIText());
        }
    }

    private IEnumerator ShowUIText()
    {
        if (uiText != null)
        {
            uiText.SetActive(true);
            yield return new WaitForSeconds(10f); 
            uiText.SetActive(false);
        }
    }
}