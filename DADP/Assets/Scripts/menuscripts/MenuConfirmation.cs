using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuConfirmation : MonoBehaviour
{
    // Reference to the confirmation panel
    public GameObject confirmationPanel;

    // Reference to the audio source for the warning sound
    private AudioSource warningSound;

    void Start()
    {
        // Get the AudioSource component attached to the ConfirmationPanel
        warningSound = confirmationPanel.GetComponent<AudioSource>();
    }

    // Method to show the confirmation panel
    public void ShowConfirmationPanel()
    {
        // Play the warning sound when the confirmation panel appears
        if (warningSound != null)
        {
            warningSound.Play();
        }

        confirmationPanel.SetActive(true);
    }

    // Method to hide the confirmation panel
    public void HideConfirmationPanel()
    {
        confirmationPanel.SetActive(false);
    }

    // Method to go back to the main menu
    public void GoToMainMenu()
    {
        // Assuming "MainMenu" is the name of your main menu scene
        SceneManager.LoadScene("MenuScene");
    }
}

