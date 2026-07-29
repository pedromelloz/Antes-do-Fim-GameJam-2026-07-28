using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [Header("Configuração")]
    public string nomeDaSuaFase = "SampleScene"; // Digite o nome EXATO da sua fase principal

    public void TentarNovamente()
    {
        // Volta para a fase do jogo
        SceneManager.LoadScene(nomeDaSuaFase);
    }

    public void IrParaMenu()
    {
        // Opcional: caso queira colocar um botão para voltar ao menu principal
        SceneManager.LoadScene("MenuPrincipal");
    }
}