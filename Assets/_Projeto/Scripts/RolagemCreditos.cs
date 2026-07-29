using UnityEngine;

public class RolagemCreditos : MonoBehaviour
{
    [Header("Configuração de Velocidade")]
    public float velocidade = 50f; // Ajuste esse valor para deixar mais rápido ou mais devagar

    void Update()
    {
        // Move o objeto para cima constantemente a cada frame
        transform.Translate(Vector3.up * velocidade * Time.deltaTime);
    }
}