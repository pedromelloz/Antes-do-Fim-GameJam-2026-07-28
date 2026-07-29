using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SistemaVidas vidasDoJogador = collision.gameObject.GetComponent<SistemaVidas>();
            
            if (vidasDoJogador != null)
            {
                // Agora enviamos o "transform" (a posição) do obstáculo para a função
                vidasDoJogador.PerderVida(transform);
            }
        }
    }
}