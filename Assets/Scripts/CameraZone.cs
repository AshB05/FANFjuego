using UnityEngine;

public class CameraZone : MonoBehaviour
{
    public Transform cameraPosition;
    public CameraFollow cameraFollow;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision is BoxCollider2D)
        {
            cameraFollow.ChangeCameraPosition(cameraPosition);
        }
    }
}