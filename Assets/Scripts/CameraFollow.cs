using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 5f;

    private Transform targetPosition;

    void Start()
    {
        targetPosition = player;
    }

    void LateUpdate()
    {
        if (targetPosition != null)
        {
            Vector3 newPosition = new Vector3(
                targetPosition.position.x,
                targetPosition.position.y,
                transform.position.z
            );

            transform.position = Vector3.Lerp(
                transform.position,
                newPosition,
                smoothSpeed * Time.deltaTime
            );
        }
    }

    public void ChangeCameraPosition(Transform newTarget)
    {
        targetPosition = newTarget;
    }
}