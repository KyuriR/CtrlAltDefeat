using UnityEngine;
using UnityEngine.UI;

public class InstructionsPanelController : MonoBehaviour
{
    // Reference to the Instructions Panel
    public GameObject instructionsPanel;

    // Method to open the instructions panel
    public void OpenInstructions()
    {
        instructionsPanel.SetActive(true);
    }

    // Method to close the instructions panel
    public void CloseInstructions()
    {
        instructionsPanel.SetActive(false);
    }
}
