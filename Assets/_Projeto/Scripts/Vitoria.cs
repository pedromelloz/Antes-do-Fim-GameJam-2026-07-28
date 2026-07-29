using UnityEngine;
using UnityEngine.SceneManagement;

public class Vitoria : MonoBehaviour
{
    [Header("Próxima Cena")]
    public string nomeCenaVitoria = "Vitoria"; // Nome da cena com o texto poético

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se quem bateu foi o Player (Dino)
        if (collision.gameObject.CompareTag("Player"))
        {
            // 1. Avisa a memória que FOI vitória
            PlayerPrefs.SetInt("FoiVitoria", 1);

            // 2. Vai para a cena de vitória (texto do tempo)
            SceneManager.LoadScene(nomeCenaVitoria);
        }
    }
}