using UnityEngine;

public class kid : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("proyectil"))
        {
            this.transform.position += Vector3.right;
            Destroy(collision.gameObject);
        }
    }
}
