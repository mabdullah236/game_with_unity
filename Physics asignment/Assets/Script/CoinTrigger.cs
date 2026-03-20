using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    // ScoreManager object ko find karne ke liye variable
    private ScoreManager scoreManager;

    void Start()
    {
        // Scene mein 'ScoreManager' dhoondo
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Tag check karo: agar player ne collect kiya
        if (other.CompareTag("Player"))
        {
            Debug.Log("Coin collected!");

            // ScoreManager ko bolo ke score badha de
            if (scoreManager != null)
            {
                scoreManager.AddScore(1); // Har coin ka 1 point
            }

            // Coin ko collect hone ke baad gayab kar do
            Destroy(gameObject);
        }
    }
}