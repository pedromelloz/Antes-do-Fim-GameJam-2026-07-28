using UnityEngine;
using UnityEngine.SceneManagement;

public class Vitoria : MonoBehaviour
{
    [Header("Configuração de Cena")]
    public string nomeCenaCinematic = "CenaMeteoro"; // Nome da cena que vamos criar

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Vai para a cena da animação/meteoro caindo
            SceneManager.LoadScene(nomeCenaCinematic);
        }
    }
}