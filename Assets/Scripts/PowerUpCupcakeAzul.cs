using UnityEngine;

public class PowerUpCupcakeAzul : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playercircus jugador = collision.GetComponentInParent<playercircus>();

        if (jugador != null)
        {
            jugador.ActivarCupcakeAzul();
            Destroy(gameObject);
        }
    }
}