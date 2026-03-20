using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // ✅ Singleton Instance

    public int score = 0;
    public TMP_Text scoreText;

    void Awake()
    {
        // ✅ If Instance already exists, destroy duplicates
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score.ToString();
    }
}
