using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneLoader : MonoBehaviour
{
  
    public void LoadNextScene()
    {
       
        SceneManager.LoadScene("MenuScene"); 
    }
    public void StartGame()
    {
        // Replace "GameScene" with the exact name of your game scene
        SceneManager.LoadScene("GameScene");
    }
}

