using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsPanel;

    // Opens the Settings panel
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    // Closes the Settings panel
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }
}
