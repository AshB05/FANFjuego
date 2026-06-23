using UnityEngine;

public class PowerUpCupcake : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playercircus jugador = collision.GetComponentInParent<playercircus>();

        if (jugador != null)
        {
            jugador.puedeLanzarCupcakes = true;

            // Esto elimina el potenciador completo de la escena
            Destroy(gameObject);
        }
    }
}