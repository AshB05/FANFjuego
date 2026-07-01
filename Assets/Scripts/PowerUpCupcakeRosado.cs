using UnityEngine;

public class PowerUpCupcakeRosado : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playercircus jugador = collision.GetComponentInParent<playercircus>();

        if (jugador != null)
        {
            jugador.ActivarCupcakeRosado();
            Destroy(gameObject);
        }
    }
}