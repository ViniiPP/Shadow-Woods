using UnityEngine;

public class Dino : MonoBehaviour
{
    [SerializeField]public float jumpForce = 5f;          // Força do pulo
    public GroundedCheck groundedCheck;   // Script que detecta se está no chão
    private Rigidbody2D rb;
    BoxCollider2D box;

    float pontosPorSegundo = 10f;
    public PointUI point;
    public bool isFreeze = false;
    public bool isCrouChing ;
    public bool isDodge;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        point = FindObjectOfType<PointUI>();
        box = GetComponent<BoxCollider2D>();
        

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

      

            if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.LeftControl)) && groundedCheck.IsGrounded())
            {
                isCrouChing = true;
            
                box.offset = new Vector2(0f, -0.19f);
            box.size = new Vector2(0.39f, 0.09f);

           

            }
            if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.LeftControl))
            {
                isCrouChing = false;
                box.offset = new Vector2(0f, 0f);
                box.size = new Vector2(0.39f, 0.8f);
            }

        if (Input.GetKey(KeyCode.LeftShift) && !groundedCheck.IsGrounded()) { 
              box.enabled = false;
              isDodge = true;   
        }

        if (isDodge && groundedCheck.IsGrounded())
        {
            box.enabled = true;
            isDodge = false;
        }

        point.AdicionarPontos(pontosPorSegundo * Time.deltaTime * 5);
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
