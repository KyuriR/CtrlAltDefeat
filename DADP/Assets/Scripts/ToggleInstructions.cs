using UnityEngine;

public class ToggleInstructions : MonoBehaviour
{
    
    public GameObject instructionsPanel;

   
    public void ShowInstructions()
    {
       
        bool isActive = instructionsPanel.activeSelf;
        instructionsPanel.SetActive(!isActive);
    }
}

