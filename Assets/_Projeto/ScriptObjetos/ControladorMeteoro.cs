using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorMeteoro : MonoBehaviour
{
    [Header("Configuração de Tempo")]
    public float tempoNaTela = 5f; // Tempo que a cena do meteoro vai ficar na tela

    void Start()
    {
        // Assim que a cena do meteoro carregar, ele conta 5 segundos e chama a função abaixo
        Invoke("MudarDeCena", tempoNaTela);
    }

    void MudarDeCena()
    {
        // Ele lê a memória que deixamos gravada no SistemaVidas ou no Vitoria
        int veioDaVitoria = PlayerPrefs.GetInt("FoiVitoria", 0);

        if (veioDaVitoria == 0)
        {
            // Se foi 0, significa que veio da DERROTA (perdeu as vidas)
            SceneManager.LoadScene("GameOver"); // Nome da sua cena de Game Over
        }
        else if (veioDaVitoria == 1)
        {
            // Se foi 1, significa que veio da VITÓRIA (chegou no fim da fase)
            SceneManager.LoadScene("Creditos"); // Nome da sua cena de Créditos
        }
    }
}