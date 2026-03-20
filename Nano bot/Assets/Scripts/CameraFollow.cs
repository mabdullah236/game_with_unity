using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Yahan hum Ball batayenge
    private Vector3 offset;  // Faasla calculate karne ke liye

    void Start()
    {
        // Game start hote hi Camera aur Ball ka faasla note kar lo
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        // Camera ko hamesha Ball ke sath ussi faaslay par rakho
        transform.position = player.position + offset;
    }
}