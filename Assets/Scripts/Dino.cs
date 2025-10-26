using UnityEngine;

public class Dino : MonoBehaviour
{
    [SerializeField]public float jumpForce = 5f;          // Força do pulo
    public GroundedCheck groundedCheck;   // Script que detecta se está no chão
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (groundedCheck == null)
        {
            Debug.LogError("❌ GroundedCheck não foi atribuído no Inspector no objeto " + gameObject.name);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && groundedCheck.IsGrounded())
        {
    
            Jump();
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }
}
