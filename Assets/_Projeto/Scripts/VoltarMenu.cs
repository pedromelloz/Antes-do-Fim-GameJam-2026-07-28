using UnityEngine;
using UnityEngine.SceneManagement;

public class VoltarMenu : MonoBehaviour
{
    [Header("Nome da Cena")]
    public string nomeCenaMenu = "MenuPrincipal"; // Coloque aqui o nome exato da sua cena de Menu

    // Esta é a função que o botão vai chamar quando for clicado
    public void CarregarMenu()
    {
        SceneManager.LoadScene(nomeCenaMenu);
    }
}