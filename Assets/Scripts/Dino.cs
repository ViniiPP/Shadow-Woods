using UnityEngine;

public class Dino : MonoBehaviour
{
    [SerializeField]public float jumpForce = 5f;          // Força do pulo
    public GroundedCheck groundedCheck;   // Script que detecta se está no chão
    private Rigidbody2D rb;

    float pontosPorSegundo = 10f;
    public PointUI point;
    public bool isFreeze = false; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        point = FindObjectOfType<PointUI>();

        if (groundedCheck == null)
        {
            Debug.LogError("❌ GroundedCheck não foi atribuído no Inspector no objeto " + gameObject.name);
        }
    }

    void Update()
    {
        if (isFreeze) return;
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && groundedCheck.IsGrounded())
        {
    
            Jump();
        }


        if (Input.GetKeyDown(KeyCode.S) && !groundedCheck.IsGrounded()) {

            forceFall();       
        }

        point.AdicionarPontos(pontosPorSegundo * Time.deltaTime);
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    void forceFall ()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, -jumpForce);
    }


}
