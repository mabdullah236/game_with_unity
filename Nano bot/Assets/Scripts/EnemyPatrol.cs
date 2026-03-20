using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 3f;      // Chalne ki taizi
    public float distance = 4f;   // Kitna door tak jaye (Left-Right range)

    private float startX; // Hum X axis (Left-Right) par chalayenge

    void Start()
    {
        startX = transform.position.x; // Jahan rakha hai wahi se shuru kare
    }

    void Update()
    {
        // PingPong function value ko 0 se Distance tak le jata hai aur wapis lata hai
        float x = Mathf.PingPong(Time.time * speed, distance);

        // Virus ko nayi jagah par set karo
        transform.position = new Vector3(startX + x - (distance / 2), transform.position.y, transform.position.z);
    }
}