using UnityEngine;
using System.Collections; // Coroutines ke liye zaroori

public class BlinkingObstacle : MonoBehaviour
{
    public float activeTime = 3f;   // Kitni dair Deewar nazar aaye
    public float inactiveTime = 2f; // Kitni dair Deewar gayab rahe

    void Start()
    {
        // Blink karna shuru karo
        StartCoroutine(BlinkRoutine());
    }

    IEnumerator BlinkRoutine()
    {
        while (true) // Hamesha chalta rahe
        {
            // Deewar dikhao (ON)
            GetComponent<Renderer>().enabled = true;
            GetComponent<Collider>().enabled = true;
            yield return new WaitForSeconds(activeTime);

            // Deewar chupao (OFF)
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            yield return new WaitForSeconds(inactiveTime);
        }
    }
}