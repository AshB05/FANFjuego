using UnityEngine;

public class cupcake : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Niño"))
        {
            Animator animadorNiño = collision.GetComponent<Animator>();

            if (animadorNiño != null)
            {
                animadorNiño.SetTrigger("Golpeado");
            }

            Destroy(gameObject);
        }
    }
}
