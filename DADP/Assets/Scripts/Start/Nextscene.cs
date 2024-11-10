using UnityEngine;
using UnityEngine.SceneManagement;

public class Nextscene : MonoBehaviour
{
    public void LoadNextScene()
    {
        // Load the next scene in the build order
        SceneManager.LoadScene("PrologueScene");

    }
    public void LoadGameScene()
    {
        // Load the next scene in the build order
        SceneManager.LoadScene("GameScene");
    }
}

