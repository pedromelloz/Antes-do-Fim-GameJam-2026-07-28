using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Painéis do Menu")]
    public GameObject painelPrincipal;
    public GameObject painelCreditos;
    public GameObject painelConfig;

    [Header("Configuração de Cenas")]
    public string nomeDaSuaFase = "SampleScene"; // Digite aqui o nome EXATO da cena do seu jogo

    void Start()
    {
        // Garante que só os botões principais apareçam quando o jogo iniciar
        VoltarAoMenu();
    }

    public void Jogar()
    {
        // Carrega a sua fase
        SceneManager.LoadScene(nomeDaSuaFase);
    }

    public void AbrirCenaCreditos()
    {
        SceneManager.LoadScene("Creditos"); // Nome exato da nova cena que criamos
    }

    public void AbrirConfig()
    {
        painelPrincipal.SetActive(false);
        painelConfig.SetActive(true);
    }

    public void VoltarAoMenu()
    {
        painelPrincipal.SetActive(true);
        painelCreditos.SetActive(false);
        painelConfig.SetActive(false);
    }

    // Essa é a função à prova de bugs para o som!
    public void MudarVolumeGeral(System.Single valorVolume)
    {
        // Altera o volume "Mestre" do jogo (de 0.0 a 1.0). 
        // Se o jogo não tiver áudio, essa linha não faz absolutamente nada (zero erros).
        AudioListener.volume = valorVolume;
    }
}