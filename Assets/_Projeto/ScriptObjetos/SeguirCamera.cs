using UnityEngine;

public class SeguirCamera : MonoBehaviour
{
    public Transform alvo; // O Dino que a câmera vai seguir
    public float suavizacao = 0.125f; // O quão suave é o movimento da câmera
    public Vector3 offset; // A distância que a câmera fica do Dino (para não colar na cara dele)

    void LateUpdate()
    {
        if (alvo != null)
        {
            // Posição desejada da câmera baseada na posição do Dino + a distância (offset)
            Vector3 posicaoDesejada = alvo.position + offset;
            
            // Move a câmera suavemente da posição atual até a posição desejada
            Vector3 posicaoSuavizada = Vector3.Lerp(transform.position, posicaoDesejada, suavizacao);
            
            // Aplica a nova posição na câmera
            transform.position = posicaoSuavizada;
        }
    }
}