using UnityEngine;

public class ToggleInstructions : MonoBehaviour
{
    // Reference to the instructions panel
    public GameObject instructionsPanel;

    // This method will be called when the Instructions button is clicked
    public void ShowInstructions()
    {
        // Toggle the panel's active state
        bool isActive = instructionsPanel.activeSelf;
        instructionsPanel.SetActive(!isActive);
    }
}

