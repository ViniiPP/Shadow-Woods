using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpForce = 8f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        // Define diretamente a velocidade vertical para o pulo
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }
}
