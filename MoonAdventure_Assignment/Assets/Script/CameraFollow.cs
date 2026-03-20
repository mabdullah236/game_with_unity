using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // PlayerParent

    void LateUpdate()
    {
        // Camera Pivot follows position only, not rotation
        transform.position = target.position;
    }
}
