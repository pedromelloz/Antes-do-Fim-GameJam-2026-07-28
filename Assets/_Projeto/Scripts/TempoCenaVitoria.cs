using UnityEngine;
using UnityEngine.SceneManagement;

public class TempoCenaVitoria : MonoBehaviour
{
    [Header("Configuração de Tempo")]
    public float tempoLendoTexto = 5f; // Quantos segundos a mensagem poética fica na tela
    public string nomeCenaMeteoro = "MeteoroCinematic"; // Para onde vai depois

    void Start()
    {
        // Começa a contagem para ir para a cena do meteoro
        Invoke("AvancarParaMeteoro", tempoLendoTexto);
    }

    void AvancarParaMeteoro()
    {
        SceneManager.LoadScene(nomeCenaMeteoro);
    }
}