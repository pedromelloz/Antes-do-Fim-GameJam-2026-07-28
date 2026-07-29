using UnityEngine;
using UnityEngine.UI;

public class Vitoria : MonoBehaviour
{
    public Text textoMensagem; // Arraste o mesmo texto de vidas aqui, ou crie um novo texto de "Você Venceu"

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se foi o jogador que encostou
        if (collision.gameObject.CompareTag("Player"))
        {
            if (textoMensagem != null)
            {
                textoMensagem.text = "VITÓRIA!!!";
            }
            Debug.Log("Você Venceu!");
            Time.timeScale = 0; // Pausa o jogo
        }
    }
}