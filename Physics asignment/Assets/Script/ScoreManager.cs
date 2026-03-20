using UnityEngine;
using TMPro; // UI TextMeshPro ko use karne ke liye yeh line zaruri hai

public class ScoreManager : MonoBehaviour
{
    private int score = 0;

    // Yeh woh Text object hai jahan hum score dikhayenge (Inspector se connect hoga)
    public TextMeshProUGUI scoreText;

    void Start()
    {
        UpdateScoreText();
    }

    // Yeh function CoinTrigger se call hoga
    public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
        UpdateScoreText();
    }

    // Yeh private function hai jo score ko UI par update karta hai
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}