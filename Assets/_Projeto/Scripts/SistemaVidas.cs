using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SistemaVidas : MonoBehaviour
{
    public int vidas = 3;
    public Text textoVidas;
    
    [Header("Configurações de Cenas")]
    public string nomeCenaGameOver = "GameOver";
    
    [Header("Configurações de Dano")]
    public float distanciaRecuo = 2f; // O quanto ele é jogado para trás

    void Start()
    {
        AtualizarTextoVidas();
    }

    // Recebemos a posição do obstáculo aqui
    public void PerderVida(Transform obstaculo)
    {
        vidas--;
        AtualizarTextoVidas();

        if (vidas <= 0)
        {
            // Acabaram as vidas, Game Over
            SceneManager.LoadScene(nomeCenaGameOver);
        }
        else
        {
            // Descobre de que lado o obstáculo bateu
            float direcao = -1f; // Empurra para a esquerda por padrão
            
            if (obstaculo.position.x < transform.position.x)
            {
                // Se o obstáculo estiver na esquerda do Dino, empurra o Dino para a direita
                direcao = 1f; 
            }

            // Move o Dino um pouco para trás no eixo X, e um pouquinho para cima no eixo Y (para não enroscar no chão)
            transform.position = new Vector2(
                transform.position.x + (direcao * distanciaRecuo), 
                transform.position.y + 1f
            );
        }
    }

    void AtualizarTextoVidas()
    {
        if (textoVidas != null)
        {
            textoVidas.text = "Vidas: " + vidas;
        }
    }
}