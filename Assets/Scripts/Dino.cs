using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class Dino : MonoBehaviour
{


    public GroundedCheck groundedCheck;

    Vector2 yVelocity;

    float maxHeight = 1f;
    float timeToPeak = 0.3f;

    float jumpSpeed;
    float gravity;

    float groundPosition = 0;

    Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravity = (2 * maxHeight) / Mathf.Pow(timeToPeak, 2);
        jumpSpeed = gravity * timeToPeak;
        groundPosition = transform.position.y;

        if (groundedCheck == null)
        {
            Debug.LogError("❌ GroundedCheck não foi atribuído no Inspector no objeto " + gameObject.name);
            return;
        }
    }

    void Update()
    {
        
        yVelocity += gravity * Time.deltaTime * Vector2.down;

        if (transform.position.y <= groundPosition && groundedCheck.IsGrounded())
        {
            transform.position = new Vector3(transform.position.x, groundPosition, transform.position.z);
            yVelocity = Vector3.zero;
        }

 
        if (Input.GetKeyDown(KeyCode.Space) && groundedCheck.IsGrounded())
        {
            yVelocity = jumpSpeed * Vector2.up;
        }


        //transform.position += (Vector3)(yVelocity * Time.deltaTime);
        rb.linearVelocity = new Vector2(0, yVelocity.y);
    }


}
