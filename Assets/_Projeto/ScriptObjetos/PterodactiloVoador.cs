using UnityEngine;

public class PterodactiloVoador : MonoBehaviour
{
    [Header("Configuração de Movimento")]
    public float velocidade = 3f;          // Velocidade que ele vai de um lado para o outro
    public float distanciaMovimento = 5f;  // Quantos metros ele anda para cada lado antes de virar
    private float posicaoInicialX;         // Guarda onde ele começou

    [Header("Configuração de Voo (Onda)")]
    public float alturaOnda = 1.5f;        // O quanto ele sobe e desce
    public float velocidadeOnda = 3f;      // A velocidade da batida de asas / subida e descida

    private int direcao = 1;               // 1 para direita, -1 para esquerda
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        posicaoInicialX = transform.position.x;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 1. Movimento Horizontal (Vai e Vem)
        transform.Translate(Vector3.right * direcao * velocidade * Time.deltaTime);

        // Verifica se passou da distância limite para inverter o lado
        if (transform.position.x > posicaoInicialX + distanciaMovimento)
        {
            direcao = -1;
            VirarSprite();
        }
        else if (transform.position.x < posicaoInicialX - distanciaMovimento)
        {
            direcao = 1;
            VirarSprite();
        }

        // 2. Movimento Vertical (Efeito de Voo subindo e descendo usando Seno)
        float novaAlturaY = transform.position.y + Mathf.Sin(Time.time * velocidadeOnda) * alturaOnda * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, novaAlturaY, transform.position.z);
    }

    void VirarSprite()
    {
        // Se o seu sprite olhar para a esquerda por padrão, inverta a lógica aqui se precisar
        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = (direcao < 0);
        }
    }

    // 3. Sistema de Dano ao encostar no Player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Tenta pegar o script SistemaVidas que está no Dino
            SistemaVidas sistemaVidas = collision.GetComponent<SistemaVidas>();

            if (sistemaVidas != null)
            {
                // Passa o Transform do Pterodáctilo para o script calcular o recuo do dano perfeitamente!
                sistemaVidas.PerderVida(transform);
            }
        }
    }
}