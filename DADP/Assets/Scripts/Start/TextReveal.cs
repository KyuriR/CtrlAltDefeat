using System.Collections;
using TMPro;
using UnityEngine;

public class TextReveal : MonoBehaviour
{
    public TextMeshProUGUI prologueText; // Link to the TextMeshPro UI component
    public float delay = 0.3f; // Delay between each word reveal

    private string fullText;
    private bool isDisplaying = false;

    void Start()
    {
        // Store the full text and clear it initially
        fullText = prologueText.text;
        prologueText.text = "";
        StartCoroutine(RevealText());
    }

    IEnumerator RevealText()
    {
        isDisplaying = true;
        string[] words = fullText.Split(' ');

        foreach (string word in words)
        {
            prologueText.text += word + " ";
            yield return new WaitForSeconds(delay);
        }

        isDisplaying = false; // Text has finished displaying
    }
}

