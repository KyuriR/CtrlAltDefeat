using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuConfirmation : MonoBehaviour
{
    
    public GameObject confirmationPanel;

    private AudioSource warningSound;

    void Start()
    {
        warningSound = confirmationPanel.GetComponent<AudioSource>();
    }

    public void ShowConfirmationPanel()
    {
        if (warningSound != null)
        {
            warningSound.Play();
        }

        confirmationPanel.SetActive(true);
    }

    
    public void HideConfirmationPanel()
    {
        confirmationPanel.SetActive(false);
    }

    
    public void GoToMainMenu()
    {
     
        SceneManager.LoadScene("MenuScene");
    }
}

