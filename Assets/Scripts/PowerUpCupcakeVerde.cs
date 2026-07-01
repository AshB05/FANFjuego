using UnityEngine;

public class PowerUpCupcakeVerde : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playercircus jugador = collision.GetComponentInParent<playercircus>();

        if (jugador != null)
        {
            jugador.ActivarCupcakeVerde();
            Destroy(gameObject);
        }
    }
}