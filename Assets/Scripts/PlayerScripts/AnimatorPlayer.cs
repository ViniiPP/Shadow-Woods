using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private Player playerScript;
    private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerScript = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (playerScript == null || rb == null || animator == null)
            return;

        // Chama o método isGrounded() do Player
        bool grounded = playerScript.isGrounded();

        // Atualiza bool isGrounded no Animator
        animator.SetBool("isGrounded", grounded);

        // Atualiza bool Run: só quando estiver no chão e se mover horizontalmente
        float horizontalSpeed = Mathf.Abs(rb.linearVelocity.x);
        animator.SetBool("Run", grounded && horizontalSpeed > 0.1f);

        // Se o player estiver no ar e subindo → dispara Trigger Jump
        if (!grounded && rb.linearVelocity.y > 0.1f)
        {
            animator.SetTrigger("Jump");
        }
    }
}
