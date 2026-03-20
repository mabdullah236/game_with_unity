using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int coinValue = 1;
    public AudioClip coinSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(coinValue);
            if (coinSound != null)
            {
                AudioSource.PlayClipAtPoint(coinSound, transform.position);
            }
            Destroy(gameObject);
        }
    }
}
