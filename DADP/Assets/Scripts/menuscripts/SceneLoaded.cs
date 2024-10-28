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
        SceneManager.LoadScene("PrologueScene");
    }
}

