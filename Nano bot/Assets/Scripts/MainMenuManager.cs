using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    void Start()
    {
        // Jab Main Menu open ho, to Cursor har haal mein nazar aana chahiye
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void StartGame()
    {
        // Level 1 load karo
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Debug.Log("Game Band ho gayi!");
        Application.Quit(); // Game band karne ke liye
    }
}