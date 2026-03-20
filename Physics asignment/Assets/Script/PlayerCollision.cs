using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Yeh function tab chalta hai jab Player kisi doosre object se takrata hai
    void OnCollisionEnter(Collision collisionInfo)
    {
        // Agar jis cheez se takraaye uska naam "Obstacle" hai
        if (collisionInfo.collider.name == "Obstacle")
        {
            // Toh console mein yeh message print karo
            Debug.Log("Player hit the obstacle!");
        }
    }
}