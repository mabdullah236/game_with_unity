using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();  // auto find karega
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            gameManager.AddScore(1);
            Destroy(other.gameObject);
        }
    }
}
