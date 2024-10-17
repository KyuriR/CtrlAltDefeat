using UnityEngine;
using UnityEngine.UI;

public class InstructionsPanelController : MonoBehaviour
{
    
    public GameObject instructionsPanel;

    
    public void OpenInstructions()
    {
        instructionsPanel.SetActive(true);
    }

    
    public void CloseInstructions()
    {
        instructionsPanel.SetActive(false);
    }
}
