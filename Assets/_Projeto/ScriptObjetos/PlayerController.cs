using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Configurações de Pulo Duplo")]
    private bool canDoubleJump = false;

    [Header("Configurações de Dash")]
    public float dashSpeed = 20f;      // Velocidade do impulso
    public float dashDuration = 0.2f;  // Tempo que dura o dash
    public float dashCooldown = 1f;    // Tempo de espera para dar outro dash
    private bool canDash = true;
    private bool isDashing = false;
    private float dashTimeLeft;
    private float nextDashTime = 0f;
    private float horizontalInput;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private float gravityOriginal;

    // --- NOVAS VARIÁVEIS DE ANIMAÇÃO E VISUAL ---
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravityOriginal = rb.gravityScale; // Salva a gravidade normal do Dino

        // Pega os componentes de animação e imagem que estão no próprio Dino
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Se estiver dando o dash, ele ignora os comandos normais por um instante
        if (isDashing)
        {
            return;
        }

        // Movimento horizontal padrão
        horizontalInput = 0f;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) horizontalInput = -1f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) horizontalInput = 1f;

        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);

        // --- CONTROLE DE ANIMAÇÃO (CORRER / PARAR) E VIRAR O SPRITE ---
        if (horizontalInput != 0)
        {
            anim.SetBool("andando", true); // Liga a animação DinoRun

            // Vira o personagem para o lado que está andando
            if (horizontalInput < 0)
            {
                spriteRenderer.flipX = true; // Olha para a esquerda
            }
            else if (horizontalInput > 0)
            {
                spriteRenderer.flipX = false; // Olha para a direita
            }
        }
        else
        {
            anim.SetBool("andando", false); // Volta para a animação DinoIdle (Parado)
        }


        // --- SISTEMA DE PULO E PULO DUPLO ---
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded)
            {
                // Pulo normal do chão
                Jump();
            }
            else if (canDoubleJump)
            {
                // Pulo duplo no ar
                Jump();
                canDoubleJump = false; // Gasta o pulo duplo até tocar no chão de novo
            }
        }

        // --- SISTEMA DE DASH ---
        // Pressionando a tecla 'Left Shift' ou 'J' para dar o dash
        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.J)) && canDash && Time.time >= nextDashTime)
        {
            StartCoroutine(PerformDash());
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        isGrounded = false;
    }

    // Usamos Coroutine para controlar o tempo exato que o Dash dura
    private System.Collections.IEnumerator PerformDash()
    {
        isDashing = true;
        canDash = false;
        
        // Descobre para qual direção o Dino está virado
        float dashDir = 1f;
        if (spriteRenderer.flipX == true) // Se ele estiver olhando para a esquerda
        {
            dashDir = -1f;
        }

        // Desliga a gravidade para o Dino não cair enquanto dá o dash no ar
        rb.gravityScale = 0f;
        rb.linearVelocity = new Vector2(dashDir * dashSpeed, 0f);

        yield return new WaitForSeconds(dashDuration);

        // Restaura a gravidade e a velocidade normal
        rb.gravityScale = gravityOriginal;
        isDashing = false;

        // Agenda o tempo de espera (cooldown) para o próximo dash
        nextDashTime = Time.time + dashCooldown;
        canDash = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            canDoubleJump = true; // Recarrega o pulo duplo sempre que toca no chão!
        }
    }
}