using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void RestartLevel()
    {
        // Dobara same level chalaye ga
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadNextLevel()
    {
        // Agla Scene load karega (Build Settings ke hisaab se)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Main Menu ka scene name yahan ayega
    }

    // NEW FUNCTION: Game ko band karna
    public void QuitGame()
    {
        // Agar hum Unity Editor mein hain:
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        // Agar hum Build/Windows/EXE mein hain:
#else
            Application.Quit();
#endif
    }
}