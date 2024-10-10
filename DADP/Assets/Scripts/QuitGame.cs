using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // Method to quit the application
    public void Quit()
    {
        // This will quit the application when the build is running
        Application.Quit();

        // If you're testing in the Unity Editor, this line helps simulate the quit function
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

