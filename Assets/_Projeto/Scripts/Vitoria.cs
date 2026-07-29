using UnityEngine;
using UnityEngine.SceneManagement;

public class Vitoria : MonoBehaviour
{
    public string nomeCenaVitoria = "Vitoria"; // Nome da cena que acabamos de criar

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(nomeCenaVitoria);
        }
    }
}